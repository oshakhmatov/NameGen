using NameGen.Core.Dto;

namespace NameGen.Core.Services.NameRules;

public class SetEndingIfSpecifiedRule : INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context)
    {
        if (context.Ending != null && context.CurrentEndingPosition != null)
        {
            return [context.Ending[context.CurrentEndingPosition.Value]];
        }

        return context.GetDefaultLetters();
    }
}
