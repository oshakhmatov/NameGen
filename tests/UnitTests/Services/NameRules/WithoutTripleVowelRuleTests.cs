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
        var context = new NameBuildingContext(Alphabet.Default, ['а', 'а', default, default], 2);

        var sut = new WithoutTripleVowelRule();

        var actual = sut.GetLetterOptions(context);

        Assert.DoesNotContain(actual, a => a.IsVowel());
    }
}