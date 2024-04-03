namespace NameGen.Extensions;

internal static class CharExtensions
{
    public static char[] Vowels = "аиэео".ToCharArray();

    public static bool IsVowel(this char c)
    {
        return Vowels.Contains(c);
    }

    
}
