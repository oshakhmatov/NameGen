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

    public string CultureName { get; set; } = "Не выбрана";

    public string Generate()
    {
        return new NameBuilder()
            .WithLength(NameLength)
            .Build();
    }

    public string GetOptions()
    {
        return $"Длина: {nameLength}\nКультура: {CultureName}";
    }
}
