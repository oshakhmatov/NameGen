using NameGen.Extensions;

namespace NameGen.Models;

public class Letter
{
    public required char Value { get; init; }
    public required char[] Combos { get; set; }
    public required char[] Endings { get; set; }

    public char[] GetVowelCombos()
    {
        return Combos.Where(x => x.IsVowel()).ToArray();
    }

    public char[] GetConsonantCombos()
    {
        return Combos.Where(x => !x.IsVowel()).ToArray();
    }

    public char[] GetVowelEndings()
    {
        return Endings.Where(x => x.IsVowel()).ToArray();
    }

    public char[] GetConsonantEndings()
    {
        return Endings.Where(x => !x.IsVowel()).ToArray();
    }

    public static bool AllVowels(params char?[] chars)
    {
        return chars.All(c => c.HasValue && c.Value.IsVowel());
    }

    public static bool AllConsonants(params char?[] chars)
    {
        return chars.All(c => c.HasValue && !c.Value.IsVowel());
    }
}
