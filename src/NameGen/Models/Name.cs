using NameGen.Services;

namespace NameGen.Models;

public class Name
{
    private readonly char[] body;
    private readonly int length;
    private readonly string[] endings;
    private readonly Letter[] letters;

    public Name(int length, string[] endings, Letter[] letters)
    {
        body = new char[length];
        this.length = length;
        this.endings = endings;
        this.letters = letters;
    }

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
            var variants = GetNextVariants(letters.First(l => l.Value == body[i + 1]), body[i + 1], i + 2 > length - 1 ? null : body[i + 2]);
            body[i] = RandomService.GetRandomItem(variants);
        }

        return new string(body);
    }

    private char[] GetNextVariants(Letter prevLetter, char prevValue, char? prevPrevValue)
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
