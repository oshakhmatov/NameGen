using NameGen.Core.Dto;
using NameGen.Core.Models;
using NameGen.Core.Services.NameRules;
using NameGen.Core.Extensions;

namespace UnitTests.Services.NameRules;

public class WithoutParticularDoubleConsonatAtStartRuleTests
{
    [Fact]
    public void WhenAtStartAndFirstIsConsonant_ReturnsVowels()
    {
        var context = new NameBuildingContext()
        {
            AvailableLetterOptions = Alphabet.Letters.First(l => l.Value == 'д').Combos,
            FirstLetter = 'д'
        };

        var sut = new WithoutParticularDoubleConsonatAtStartRule();

        var actual = sut.GetLetterOptions(context);

        Assert.DoesNotContain(actual, a => !a.IsVowel());
    }
}
