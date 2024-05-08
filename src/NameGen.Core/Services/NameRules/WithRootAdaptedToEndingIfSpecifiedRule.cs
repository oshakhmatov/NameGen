using NameGen.Core.Dto;
using NameGen.Core.Extensions;
using NameGen.Core.Models;

namespace NameGen.Core.Services.NameRules;

public class WithRootAdaptedToEndingIfSpecifiedRule : INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context)
    {
        if (context.Ending != null && context.Root![^1] == default(char) && context.Root![^2] != default(char))
        {
            var endingLetter = context.Ending.First();

            var letters = Alphabet.Letters
                .Where(l => l.Combos.Contains(endingLetter))
                .Select(l => l.Value)
                .Where(v => context.PrevLetter!.Combos.Contains(v))
                .ToArray();

            if (endingLetter.IsVowel())
            {
                return letters.Where(l => l.IsConsonant()).ToArray();
            }
            else
            {
                return letters.Where(l => l.IsVowel()).ToArray();
            }
        }

        return context.AvailableLetterOptions!;
    }
}