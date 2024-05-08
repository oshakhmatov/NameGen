using NameGen.Core.Models;

namespace NameGen.Core.Dto;

public record NameBuildingContext(
    char[]? AvailableLetterOptions = default,
    Letter? PrevLetter = default,
    char? PrevPrevValue = default,
    char? FirstLetter = default,
    char[]? Root = default,
    string? Ending = default);
