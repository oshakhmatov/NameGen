using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NameGen.Core.Dto;
using NameGen.Core.Services;
using System.Text;

Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

var helpMessage =
    "/////////////////////////////////////////////////////////\n" +
    "NameGen v1.0\n" +
    "Настройки культур можно изменить в файле appsettings.json\n" +
    "/////////////////////////////////////////////////////////\n" +
    "Для просмотра этих команд: помощь\n" +
    "Для просмотра опций: опции\n" +
    "Для просмотра списка культур: культуры\n" +
    "Задать первую букву: <буква> (например: а)\n" +
    "Для установки культуры: культура <название> (например: культура экронская)\n" +
    "Для установки длины: длина <значение> (например: длина 6). От 2 до 12";


Console.WriteLine(helpMessage);
Console.WriteLine();

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddOptions();
        services.Configure<CultureOptions>(hostContext.Configuration.GetSection(nameof(CultureOptions)));
        services.AddSingleton<NameGenerator>();
    })
    .Build();

var nameGenerator = host.Services.GetRequiredService<NameGenerator>();

while (true)
{
    var input = Console.ReadLine();

    if (input.StartsWith("опции"))
    {
        Console.WriteLine($"///\n{nameGenerator.GetOptions()}\n///");
    }
    else if (input.StartsWith("длина"))
    {
        nameGenerator.NameLength = Int32.Parse(input.Split().Last());
    }
    else if (input.StartsWith("культура"))
    {
        nameGenerator.CultureName = input.Split().Last();
        Console.WriteLine($"///\n{nameGenerator.GetCultureInfo()}\n///");
    }
    else if (input.StartsWith("культуры"))
    {
        Console.WriteLine($"///\n{nameGenerator.GetCultures()}\n///");
    }
    else if (input.StartsWith("помощь"))
    {
        Console.WriteLine(helpMessage);
    }
    else
    {
        Console.WriteLine(nameGenerator.Generate(input.FirstOrDefault()));
    }
}
