using NameGen.Core.Dto;
using NameGen.Core.Models;
using NameGen.Core.Services.NameRules;
using NameGen.Core.Extensions;

namespace UnitTests.Services.NameRules;

public class WithoutTripleVowelRuleTests
{
    [Fact]
    public void WhenTwoVowelsExist_ReturnsConsonants()
    {
        var context = new NameBuildingContext()
        {
            AvailableLetterOptions = Alphabet.Letters.First(l => l.Value == 'а').Combos,
            PrevLetter = Alphabet.Letters.First(l => l.Value == 'а'),
            PrevPrevValue = 'а'
        };

        var sut = new WithoutTripleVowelRule();

        var actual = sut.GetLetterOptions(context);

        Assert.DoesNotContain(actual, a => a.IsVowel());
    }
}