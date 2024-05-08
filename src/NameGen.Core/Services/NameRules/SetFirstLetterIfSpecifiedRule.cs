using NameGen.Core.Dto;

namespace NameGen.Core.Services.NameRules;

public class SetFirstLetterIfSpecifiedRule : INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context)
    {
        if (context.CurrentPosition != 0 || context.FirstLetter == null)
        {
            return context.GetDefaultLetters();
        }

        return [context.FirstLetter.Value];
    }
}
