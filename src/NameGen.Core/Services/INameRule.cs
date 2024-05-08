using NameGen.Core.Dto;

namespace NameGen.Core.Services;

public interface INameRule
{
    public char[] GetLetterOptions(NameBuildingContext context);
}
