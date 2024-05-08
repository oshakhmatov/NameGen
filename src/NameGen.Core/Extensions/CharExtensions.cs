namespace NameGen.Core.Extensions;

public static class CharExtensions
{
    private static readonly char[] Vowels = "аиэуюяёыео".ToCharArray();

    public static bool IsVowel(this char c)
    {
        return Vowels.Contains(c);
    }

    public static bool IsConsonant(this char c)
    {
        return !c.IsVowel();
    }

    public static string ToUpper(this char c)
    {
        return c.ToString().ToUpper();
    }
}
