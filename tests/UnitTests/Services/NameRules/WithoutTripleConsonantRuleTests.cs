using NameGen.Core.Dto;
using NameGen.Core.Extensions;
using NameGen.Core.Models;
using NameGen.Core.Services.NameRules;

namespace UnitTests.Services.NameRules;

public class WithoutTripleConsonantRuleTests
{
    [Fact]
    public void WhenTwoConsonantsExist_ReturnsVowels()
    {
        var context = new NameBuildingContext(Alphabet.Default, ['д', 'д', default, default], 2);

        var sut = new WithoutTripleConsonantRule();

        var actual = sut.GetLetterOptions(context);

        Assert.DoesNotContain(actual, a => a.IsConsonant());
    }
}
