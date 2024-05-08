namespace NameGen.Core.Services;

public class Randomizer
{
    private static readonly Random random = new();

    public static T TakeFrom<T>(T[] variants)
    {
        if (variants.Length == 0)
        {
            throw new ApplicationException("Нет вариантов для выбора элемента");
        }
        var index = random.Next(0, variants.Length);
        return variants[index];
    }
}
