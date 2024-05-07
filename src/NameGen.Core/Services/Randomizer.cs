namespace NameGen.Core.Services;

public class Randomizer
{
    private static readonly Random random = new();

    public static T TakeFrom<T>(T[] variants)
    {
        var index = random.Next(0, variants.Length);
        return variants[index];
    }
}
