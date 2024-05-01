using NameGen.Core.Services;

namespace NameGen.Core.Models;

public class Name(int length, string[] endings, Letter[] letters)
{
    private readonly char[] body = new char[length];
    private readonly int length = length;
    private readonly string[] endings = endings;
    private readonly Letter[] letters = letters;

    public string Build()
    {
        var ending = RandomService.GetRandomItem(endings);

        var endingIndex = ending.Length - 1;
        for (int i = length - 1; i >= length - ending.Length; i--)
        {
            body[i] = ending[endingIndex];
            endingIndex--;
        }

        for (int i = length - ending.Length - 1; i >= 0; i--)
        {
            var variants = Name.GetNextVariants(letters.First(l => l.Value == body[i + 1]), body[i + 1], i + 2 > length - 1 ? null : body[i + 2]);
            body[i] = RandomService.GetRandomItem(variants);
        }
        var result = new string(body);
        return string.Concat(result.First().ToString().ToUpper(), result.AsSpan(1));
    }

    private static char[] GetNextVariants(Letter prevLetter, char prevValue, char? prevPrevValue)
    {
        if (Letter.AllConsonants(prevValue, prevPrevValue))
        {
            return prevLetter.GetVowelCombos();
        }
        else if (Letter.AllVowels(prevValue, prevPrevValue))
        {
            return prevLetter.GetConsonantCombos();
        }
        else
        {
            return prevLetter.Combos;
        }
    }
}
