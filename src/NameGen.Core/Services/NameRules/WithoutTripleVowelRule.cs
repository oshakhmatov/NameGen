using NameGen.Core.Dto;
using NameGen.Core.Extensions;

namespace NameGen.Core.Services.NameRules;

public class WithoutTripleVowelRule : INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context)
    {
        if (context.CurrentPosition > 1 && context.PrevLetter.IsVowel() && context.PrevPrevLetter.IsVowel())
        {
            return context.GetDefaultConsonants();
        }

        return context.GetDefaultLetters();
    }
}
