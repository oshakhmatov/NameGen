namespace NameGen.Core.Dto;

public class Culture
{
    public string Name { get; set; }
    public char[] ExcludeLetters { get; set; }
    public string[] Endings { get; set; }
}
