using NameGen.Core.Models;

namespace NameGen.Core.Services;

public class NameGenerator
{
    private int nameLength = 6;

    public int NameLength
    {
        get { return nameLength; }
        set
        {
            if (value is > 2 and < 11)
            {
                nameLength = value;
            }
        }
    }

    public string Generate()
    {
        var name = new Name(nameLength, Alphabet.Endings, Alphabet.Letters);

        return name.Build();
    }
}
