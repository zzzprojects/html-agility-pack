using Xunit;

namespace HtmlAgilityPack.Tests.NetStandard2_0
{
    public class HtmlEntityDeEntitizeTests
    {
        [Theory]
        // Invalid numeric entities must be left untouched; "&#foo;" used to become
        // "&##foo;".
        [InlineData("&#foo;", "&#foo;")]
        [InlineData("&#xGG;", "&#xGG;")]
        [InlineData("&#;", "&#;")]
        [InlineData("prefix &#foo; suffix", "prefix &#foo; suffix")]
        // Valid numeric entities keep decoding correctly.
        [InlineData("&#65;", "A")]
        [InlineData("&#x41;", "A")]
        // Named entities are unaffected.
        [InlineData("&amp;", "&")]
        [InlineData("&notreal;", "&notreal;")]
        public void DeEntitize_HandlesInvalidNumericEntitiesWithoutDuplicatingHash(string input, string expected)
        {
            Assert.Equal(expected, HtmlEntity.DeEntitize(input));
        }
    }
}
