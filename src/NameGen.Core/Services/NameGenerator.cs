using Microsoft.Extensions.Options;
using NameGen.Core.Dto;
using NameGen.Core.Models;
using NameGen.Core.Services.NameRules;
using Polly;
using System.Text;

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
                .Retry(retryCount: 10);

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
            return $"Алгоритм не смог сгенерировать имя с 10 попыток, попробуйте изменить настройки.\nПричина ошибки: {ex.Message}";
        }

    }

    public string GetOptions()
    {
        return $"Длина: {nameLength}\nКультура: {CultureName}";
    }

    public string GetCultures()
    {
        var cultureInfos = new List<string>();
        for (var i=0; i < options.CurrentValue.Cultures.Length; i++)
        {
            cultureInfos.Add($"{i+1}. {options.CurrentValue.Cultures[i].Name}");
        }
        return String.Join("\n", cultureInfos);
    }

    public string GetCultureInfo()
    {
        var culture = options.CurrentValue.Cultures.FirstOrDefault(c => c.Name == CultureName);
        if (culture == null)
        {
            return $"Культура с названием '{CultureName}' не найдена";
        }

        var sb = new StringBuilder();
        sb.AppendLine($"Исключать: {String.Join(", ", culture.ExcludeLetters)}");
        sb.Append($"Окончания: {String.Join(", ", culture.Endings)}");
        return sb.ToString();
    }
}
