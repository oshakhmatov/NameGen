using NameGen.Core.Dto;
using NameGen.Core.Extensions;
using NameGen.Core.Services;

namespace NameGen.Core.Models;

public class NameBuilder
{
    private NameBuildingContext context = new();
    private INameRule[] rules;
    private Letter[] letters;
    private int length;

    public NameBuilder()
    {
        rules = [];
        letters = Alphabet.Letters;
        context = new();
        length = 6;
    }

    public NameBuilder WithFirstLetter(char? firstLetter)
    {
        context = context with { FirstLetter = firstLetter };
        return this;
    }

    public NameBuilder WithLength(int length)
    {
        this.length = length;
        return this;
    }

    public NameBuilder ExcludeLetters(char[] lettersToExclude)
    {
        letters = letters
            .Where(l => !lettersToExclude.Contains(l.Value))
            .ToArray();

        foreach (var letter in letters)
        {
            letter.Combos = letter.Combos
                .Where(c => !lettersToExclude.Contains(c))
                .ToArray();

            letter.Endings = letter.Endings
                .Where(c => !lettersToExclude.Contains(c))
                .ToArray();
        }

        return this;
    }

    public NameBuilder WithEndings(string[] endings)
    {
        context = context with { Ending = Randomizer.TakeFrom(endings) };
        return this;
    }

    public NameBuilder ApplyRules(params INameRule[] rules)
    {
        this.rules = rules;
        return this;
    }

    // fix 'Амлкал'
    // adjust root to ending if specified
    public string Build()
    {
        context = context with
        {
            Root = new char[GetRootLength()]
        };

        if (context.FirstLetter == null || GetLetterByValue(context.FirstLetter.Value) == null)
        {
            context = context with
            {
                FirstLetter = Randomizer.TakeFrom(letters).Value
            };
        }

        context = context with 
        {
            PrevLetter = GetLetterByValue(context.FirstLetter.Value)
        };

        for (int i = 0; i < context.Root.Length; i++)
        {
            context.Root[i] = Randomizer.TakeFrom(GetNextLetterOptions(context.PrevLetter!.Combos));
            context = context with
            {
                PrevPrevValue = i > 1 ? context.Root[i - 2] : context.FirstLetter,
                PrevLetter = GetLetterByValue(context.Root[i])
            };
        }

        if (context.Ending == null)
        {
            context = context with
            {
                Ending = Randomizer.TakeFrom(GetNextLetterOptions(context.PrevLetter!.Endings)).ToString()
            };
        }

        return string.Concat(context.FirstLetter.Value.ToUpper(), new string(context.Root), context.Ending);
    }

    private int GetRootLength()
    {
        var firstLetterLength = 1;
        var endingLength = context.Ending == default ? 1 : context.Ending.Length;
        return length - firstLetterLength - endingLength;
    }

    private Letter? GetLetterByValue(char value)
    {
        return letters.FirstOrDefault(l => l.Value == value);
    }

    private char[] GetNextLetterOptions(char[] availableLetterOptions)
    {
        context = context with { AvailableLetterOptions = availableLetterOptions };
        foreach (var rule in rules)
        {
            context = context with { AvailableLetterOptions = rule.GetLetterOptions(context) };
        }
        return context.AvailableLetterOptions;
    }
}
