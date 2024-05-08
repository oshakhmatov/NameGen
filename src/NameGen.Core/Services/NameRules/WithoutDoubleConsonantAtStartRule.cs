using NameGen.Core.Dto;
using NameGen.Core.Extensions;

namespace NameGen.Core.Services.NameRules;

public class WithoutDoubleConsonantAtStartRule : INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context)
    {
        if (context.CurrentPosition == 1 && context.PrevLetter.IsConsonant())
        {
            return context.GetDefaultVowels();
        }

        return context.GetDefaultLetters();
    }
}
