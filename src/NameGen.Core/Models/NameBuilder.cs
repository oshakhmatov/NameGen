using NameGen.Core.Services;

namespace NameGen.Core.Models;

public class NameBuilder
{
    private INameRule[]? rules;
    private readonly Alphabet alphabet;
    private char? firstLetter;
    private string? ending;
    private int length;

    public NameBuilder()
    {
        alphabet = Alphabet.Default;
        length = 6;
        firstLetter = null;
    }

    public NameBuilder WithFirstLetter(char firstLetter)
    {
        if (firstLetter != default)
        {
            this.firstLetter = firstLetter;
        }
        return this;
    }

    public NameBuilder WithLength(int length)
    {
        this.length = length;
        return this;
    }

    public NameBuilder ExcludeLetters(char[] lettersToExclude)
    {
        alphabet.ExcludeLetters(lettersToExclude);
        return this;
    }

    public NameBuilder WithEndings(string[] endings)
    {
        ending = Randomizer.TakeFrom(endings);
        return this;
    }

    public NameBuilder ApplyRules(params INameRule[] rules)
    {
        this.rules = rules;
        return this;
    }

    public string Build()
    {
        return new Name(
            alphabet,
            length, 
            firstLetter,
            ending,
            rules).Value;
    }
}
