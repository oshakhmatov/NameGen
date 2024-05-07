using NameGen.Core.Services;

namespace NameGen.Core.Models;

public class NameBuilder
{
    private Letter[] letters;
    private char firstLetter;
    private int length;
    private string ending;

    public NameBuilder()
    {
        letters = Alphabet.Letters;
        firstLetter = default;
        length = 6;
    }

    public NameBuilder WithFirstLetter(char firstLetter)
    {
        this.firstLetter = firstLetter;
        return this;
    }

    public NameBuilder WithLength(int length)
    {
        this.length = length;
        return this;
    }

    public NameBuilder WithEnding(string ending)
    {
        this.ending = ending;
        return this;
    }

    public string Build()
    {
        var body = new char[length];

        if (ending == default)
        {
            ending = Randomizer.TakeFrom(letters.Select(l => l.Value).ToArray()).ToString();
        }

        var endingIndex = ending.Length - 1;
        for (int i = length - 1; i >= length - ending.Length; i--)
        {
            body[i] = ending[endingIndex];
            endingIndex--;
        }

        for (int i = length - ending.Length - 1; i >= 0; i--)
        {
            var variants = GetNextVariants(letters.First(l => l.Value == body[i + 1]), body[i + 1], i + 2 > length - 1 ? null : body[i + 2]);
            body[i] = Randomizer.TakeFrom(variants);
        }

        var result = new string(body);

        return string.Concat(result.First().ToString().ToUpper(), result.AsSpan(1));
    }

    private static char[] GetNextVariants(Letter prevLetter, char prevValue, char? prevPrevValue)
    {
        if (Letter.AllConsonants(prevValue, prevPrevValue))
        {
            return prevLetter.GetVowelCombos();
        }
        else if (Letter.AllVowels(prevValue, prevPrevValue))
        {
            return prevLetter.GetConsonantCombos();
        }
        else
        {
            return prevLetter.Combos;
        }
    }
}
