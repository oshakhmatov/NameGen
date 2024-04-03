using Microsoft.Extensions.Options;
using NameGen.Dto;
using NameGen.Models;

namespace NameGen.Services;

public class NameGenerator
{
    private int nameLength = 6;
    private string cultureName = "экрон";
    private Letter[] letters = Alphabet.Letters;
    private Culture? culture;
    private string[] endings = Alphabet.Endings;

    private readonly IOptionsMonitor<CultureOptions> optionsMonitor;

    public NameGenerator(IOptionsMonitor<CultureOptions> optionsMonitor)
    {
        this.optionsMonitor = optionsMonitor;
    }

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

    public string CultureName
    {
        get { return cultureName; }
        set
        {
            var options = optionsMonitor.CurrentValue;
            if (options.Cultures.Any(c => c.Name == value))
            {
                cultureName = value;
            }
        }
    }

    public string GetOptions()
    {
        return $"Длина: {nameLength}\nКультура: {cultureName}";
    }

    public string Generate()
    {
        SetVariables();

        var name = new Name(nameLength, endings, letters);

        return name.Build();
    }

    private void SetVariables()
    {
        if (cultureName != "Не установлена")
        {
            culture = optionsMonitor.CurrentValue.Cultures.First(c => c.Name == cultureName);

            letters = Alphabet.Letters.Where(l => !culture.ExcludeLetters.Contains(l.Value)).ToArray();
            endings = Alphabet.Endings.Where(l => culture.Endings.Contains(l)).ToArray();

            foreach (var letter in letters)
            {
                letter.Combos = letter.Combos.Where(c => !culture.ExcludeLetters.Contains(c)).ToArray();
                
            }
        }
        else
        {
            culture = null;
            letters = Alphabet.Letters;
            endings = Alphabet.Endings;
        }
    }
}
