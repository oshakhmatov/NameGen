using Microsoft.Extensions.Options;
using NameGen.Core.Dto;
using NameGen.Core.Models;
using NameGen.Core.Services.NameRules;
using Polly;

namespace NameGen.Core.Services;

public class NameGenerator(IOptionsMonitor<CultureOptions> options)
{
    private readonly IOptionsMonitor<CultureOptions> options = options;
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

    public string Generate(char firstLetter)
    {
        if (firstLetter != default)
        {
            firstLetter = firstLetter
                .ToString()!
                .ToLowerInvariant()
                .First();
        }

        if (CultureName != null)
        {
            CultureName = CultureName.ToLowerInvariant();
        }

        var culture = options.CurrentValue.Cultures.FirstOrDefault(c => c.Name == CultureName);

        try
        {
            var policy = Policy
                .Handle<Exception>()
                .Retry(retryCount: 3);

            return policy.Execute(() =>
            {
                var nameBuilder = new NameBuilder()
                    .WithLength(NameLength)
                    .WithFirstLetter(firstLetter);

                if (culture != null)
                {
                    nameBuilder = nameBuilder
                        .ExcludeLetters(culture.ExcludeLetters)
                        .WithEndings(culture.Endings);
                }

                return nameBuilder
                    .ApplyRules(
                        new WithoutTripleConsonantRule(),
                        new WithoutTripleVowelRule(),
                        new WithRootAdaptedToEndingIfSpecifiedRule(),
                        new WithoutDoubleConsonantAtStartRule())
                    .Build();
            });
        }
        catch (Exception ex)
        {
            return $"Алгоритм не смог сгенерировать имя с 3 попыток, попробуйте изменить настройки.\nПричина ошибки: {ex.Message}";
        }

    }

    public string GetOptions()
    {
        return $"Длина: {nameLength}\nКультура: {CultureName}";
    }
}
