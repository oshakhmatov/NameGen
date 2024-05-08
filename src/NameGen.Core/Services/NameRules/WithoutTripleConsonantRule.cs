using NameGen.Core.Dto;
using NameGen.Core.Extensions;
using NameGen.Core.Models;

namespace NameGen.Core.Services.NameRules;

public class WithoutTripleConsonantRule : INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context)
    {
        if (Letter.AllConsonants(context.PrevLetter!.Value, context.PrevPrevValue))
        {
            return context.AvailableLetterOptions!.Where(a => a.IsVowel()).ToArray();
        }

        return context.AvailableLetterOptions!;
    }
}
