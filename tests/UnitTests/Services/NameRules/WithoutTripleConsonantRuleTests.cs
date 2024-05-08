using NameGen.Core.Dto;
using NameGen.Core.Models;
using NameGen.Core.Services.NameRules;
using NameGen.Core.Extensions;

namespace UnitTests.Services.NameRules;

public class WithoutTripleConsonantRuleTests
{
    [Fact]
    public void WhenTwoConsonantsExist_ReturnsVowels()
    {
        var context = new NameBuildingContext()
        {
            AvailableLetterOptions = Alphabet.Letters.First(l => l.Value == 'д').Combos,
            PrevLetter = Alphabet.Letters.First(l => l.Value == 'д'),
            PrevPrevValue = 'д'
        };

        var sut = new WithoutTripleConsonantRule();

        var actual = sut.GetLetterOptions(context);

        Assert.DoesNotContain(actual, a => a.IsConsonant());
    }
}
