using NameGen.Core.Dto;
using NameGen.Core.Extensions;

namespace NameGen.Core.Services.NameRules;

public class WithoutParticularDoubleConsonatAtStartRule : INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context)
    {
        if (context.PrevPrevValue == null && context.FirstLetter!.Value.IsConsonant())
        {
            return context.AvailableLetterOptions!.Where(a => a.IsVowel()).ToArray();
        }

        return context.AvailableLetterOptions!;
    }
}
