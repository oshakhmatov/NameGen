using NameGen.Core.Extensions;
using NameGen.Core.Models;
using Polly;

namespace NameGen.Core.Dto;

public class NameBuildingContext(
    Alphabet alphabet,
    char[] body,
    int currentPosition,
    char? firstLetter = default,
    string? ending = default)
{
    public Alphabet Alphabet { get; } = alphabet;
    public char[] Body { get; } = body;
    public int CurrentPosition { get; } = currentPosition;
    public char? FirstLetter { get; } = firstLetter;
    public string? Ending { get; } = ending;

    public char CurrentLetter => Body[CurrentPosition];
    public char PrevLetter => Body[CurrentPosition - 1];
    public char PrevPrevLetter => Body[CurrentPosition - 2];
    public int? CurrentEndingPosition => CurrentPosition >= Body.Length - (Ending?.Length ?? 1) ?
        Math.Abs(Body.Length - CurrentPosition - Ending!.Length) :
        null;

    public char[] GetDefaultLetters()
    {
        if (CurrentPosition == 0)
        {
            return Alphabet.GetAllLetterValues();
        }
        else if (CurrentPosition == Body.Length - 1)
        {
            return Alphabet.GetLetter(Body[^2]).Endings;
        }
        else
        {
            return Alphabet.GetLetter(Body[CurrentPosition - 1]).Combos;
        }
    }

    public char[] GetDefaultVowels()
    {
        return GetDefaultLetters().Where(l => l.IsVowel()).ToArray();
    }

    public char[] GetDefaultConsonants()
    {
        return GetDefaultLetters().Where(l => l.IsConsonant()).ToArray();
    }
}
