using NameGen.Core.Dto;
using NameGen.Core.Extensions;
using NameGen.Core.Models;

namespace NameGen.Core.Services.NameRules;

public class WithoutTripleVowelRule : INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context)
    {
        if (Letter.AllVowels(context.PrevLetter!.Value, context.PrevPrevValue))
        {
            return context.AvailableLetterOptions!.Where(a => a.IsConsonant()).ToArray();
        }

        return context.AvailableLetterOptions!;
    }
}
