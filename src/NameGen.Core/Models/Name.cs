using NameGen.Core.Dto;
using NameGen.Core.Extensions;
using NameGen.Core.Services;
using NameGen.Core.Services.NameRules;

namespace NameGen.Core.Models;

public class Name
{
    private readonly Alphabet alphabet;
    private readonly char? firstLetter;
    private readonly string? ending;
    private readonly char[] body;
    private readonly List<INameRule> rules;
    private int currentPosition;

    public string Value { get; }

    public Name(
        Alphabet alphabet,
        int length,
        char? firstLetter = default,
        string? ending = default,
        INameRule[]? rules = default)
    {
        body = new char[length];
        currentPosition = 0;

        this.alphabet = alphabet;
        this.firstLetter = firstLetter;
        this.ending = ending;
        this.rules = [
            new SetFirstLetterIfSpecifiedRule(),
            new SetEndingIfSpecifiedRule()
        ];

        if (rules != null)
        {
            this.rules.AddRange(rules);
        }

        for (; currentPosition < length; currentPosition++)
        {
            var letterOptions = GetLetterOptions();
            body[currentPosition] = Randomizer.TakeFrom(letterOptions);
        }

        Value = string.Concat(body[0].ToUpper(), new string(body[1..]));
    }

    private char[] GetLetterOptions()
    {
        return rules
            .Select(r =>
            {
                var t = r.GetLetterOptions(
                new NameBuildingContext(alphabet, body, currentPosition, firstLetter, ending));
                return t;
            })
            .Aggregate((previous, current) => previous
                .Intersect(current)
                .ToArray());
    }
}
