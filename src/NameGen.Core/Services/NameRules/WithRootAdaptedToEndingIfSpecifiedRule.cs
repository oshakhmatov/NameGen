using NameGen.Core.Dto;
using NameGen.Core.Extensions;

namespace NameGen.Core.Services.NameRules;

public class WithRootAdaptedToEndingIfSpecifiedRule : INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context)
    {
        if (context.Ending != null &&
            context.CurrentEndingPosition == null &&
            context.CurrentPosition == context.Body.Length - context.Ending.Length - 2)
        {
            var endingLetter = context.Ending.First();

            var letters = context.Alphabet.GetAllLetters()
                .Where(l => l.Combos.Contains(endingLetter))
                .Select(l => l.Value)
                .Where(v => context.Alphabet.GetLetter(context.PrevLetter).Combos.Contains(v))
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

        return context.GetDefaultLetters();
    }
}