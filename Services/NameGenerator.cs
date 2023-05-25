using Microsoft.Extensions.Options;
using NameGen.Dto;
using NameGen.Extensions;
using NameGen.Models;
using System.Text;

namespace NameGen.Services;

public class NameGenerator
{
    private int nameLength = 6;
    private string cultureName = "Не установлена";
    private Letter[] letters = Alphabet.Letters;
    private Culture? culture;

    private readonly IOptionsMonitor<CultureOptions> optionsMonitor;

    public NameGenerator(IOptionsMonitor<CultureOptions> optionsMonitor)
    {
        this.optionsMonitor = optionsMonitor;
    }

    public int NameLength
    {
        get { return nameLength; }
        set
        {
            if (value is > 2 and < 11)
            {
                nameLength = value;
            }
        }
    }

    public string CultureName
    {
        get { return cultureName; }
        set
        {
            var options = optionsMonitor.CurrentValue;
            if (options.Cultures.Any(c => c.Name == value))
            {
                cultureName = value;
            }
        }
    }

    public string GetOptions()
    {
        return $"Длина: {nameLength}\nКультура: {cultureName}";
    }

    public string Generate()
    {
        SetVariables();

        var name = new StringBuilder(nameLength);

        var letter = GetFirst();
        name.Append(char.ToUpper(letter));

        var prevValue = letter;

        var second = GetSecond(prevValue);
        name.Append(second);

        var prevPrevValue = prevValue;
        prevValue = second;

        for (var i = 2; i < nameLength - 1; i++)
        {
            letter = GetNext(prevValue, prevPrevValue);
            name.Append(letter);

            prevPrevValue = prevValue;
            prevValue = letter;
        }

        var ending = GetEnding(prevValue, prevPrevValue);

        var currentName = name.ToString();

        if (currentName.Last() == ending.First())
        {
            name.Append(ending.Skip(1));
        }
        else
        {
            name.Append(ending);
        }

        return name.ToString();
    }

    private char GetFirst()
    {
        return RandomService.GetRandomItem(letters).Value;
    }

    private char GetSecond(char prevValue)
    {
        return GetNextChar(prevValue, GetSecondVariants);
    }

    private char GetNext(char prevValue, char? prevPrevValue)
    {
        return GetNextChar(prevValue, GetNextVariants, prevPrevValue);
    }

    private string GetEnding(char prevValue, char? prevPrevValue)
    {
        if (cultureName == "Не установлена")
        {
            return GetNextChar(prevValue, GetEndingVariants, prevPrevValue).ToString();
        }
        else
        {
            return RandomService.GetRandomItem(culture.Endings);
        }
    }

    private char GetNextChar(
        char prevValue,
        Func<Letter, char, char?, char[]> variantsResolver,
        char? prevPrevValue = default)
    {
        var prevLetter = GetLetterByChar(prevValue);

        var charVariants = variantsResolver.Invoke(prevLetter, prevValue, prevPrevValue);

        return RandomService.GetRandomItem(charVariants);
    }

    private char[] GetEndingVariants(Letter prevLetter, char prevValue, char? prevPrevValue)
    {
        if (AllConsonants(prevValue, prevPrevValue))
        {
            return prevLetter.GetVowelEndings();
        }
        else if (AllVowels(prevValue, prevPrevValue))
        {
            return prevLetter.GetConsonantEndings();
        }
        else
        {
            return prevLetter.Endings;
        }
    }

    private char[] GetNextVariants(Letter prevLetter, char prevValue, char? prevPrevValue)
    {
        if (AllConsonants(prevValue, prevPrevValue))
        {
            return prevLetter.GetVowelCombos();
        }
        else if (AllVowels(prevValue, prevPrevValue))
        {
            return prevLetter.GetConsonantCombos();
        }
        else
        {
            return prevLetter.Combos;
        }
    }

    private char[] GetSecondVariants(Letter prevLetter, char prevValue, char? prevPrevValue)
    {
        if (prevValue.IsVowel())
        {
            return prevLetter.Combos;
        }
        else
        {
            return prevLetter.GetVowelCombos();
        }
    }

    private Letter GetLetterByChar(char ch)
    {
        return letters.First(x => x.Value == ch);
    }

    private static bool AllVowels(params char?[] chars)
    {
        return chars.All(c => c.HasValue && c.Value.IsVowel());
    }

    private static bool AllConsonants(params char?[] chars)
    {
        return chars.All(c => c.HasValue && !c.Value.IsVowel());
    }

    private void SetVariables()
    {
        if (cultureName != "Не установлена")
        {
            culture = optionsMonitor.CurrentValue.Cultures.First(c => c.Name == cultureName);

            letters = Alphabet.Letters.Where(l => culture.ExcludeLetters.Contains(l.Value)).ToArray();

            foreach (var letter in letters)
            {
                letter.Combos = letter.Combos.Where(c => culture.ExcludeLetters.Contains(c)).ToArray();
            }
        }
        else
        {
            culture = null;
            letters = Alphabet.Letters;
        }
    }
}
