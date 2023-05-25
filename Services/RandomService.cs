namespace NameGen.Services;

public class RandomService
{
    private static readonly Random random = new();

    public static T GetRandomItem<T>(T[] variants)
    {
        var index = random.Next(0, variants.Length);
        return variants[index];
    }
}
