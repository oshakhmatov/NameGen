using System.Text;

namespace NameGen.Models;

public class Name
{
    public static string Generate(int length, string[] endings, char[] excludeLetters)
    {
        var name = new StringBuilder(length);

        var ending = GetEnding(prevValue, prevPrevValue);

        var letter = GetFirst();
        name.Append(char.ToUpper(letter));

        var prevValue = letter;

        var second = GetSecond(prevValue);
        name.Append(second);

        var prevPrevValue = prevValue;
        prevValue = second;

        for (var i = 2; i < length - 1; i++)
        {
            letter = GetNext(prevValue, prevPrevValue);
            name.Append(letter);

            prevPrevValue = prevValue;
            prevValue = letter;
        }

        var ending = GetEnding(prevValue, prevPrevValue);

        var currentName = name.ToString();

        if (currentName.Last() == ending.First())
        {
            name.Append(ending.Skip(1));
        }
        else
        {
            name.Append(ending);
        }

        return name.ToString();
    }
}
