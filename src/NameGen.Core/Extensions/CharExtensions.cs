namespace NameGen.Core.Extensions;

internal static class CharExtensions
{
    public static char[] Vowels = "аиэуюяёыео".ToCharArray();

    public static bool IsVowel(this char c)
    {
        return Vowels.Contains(c);
    }
}
