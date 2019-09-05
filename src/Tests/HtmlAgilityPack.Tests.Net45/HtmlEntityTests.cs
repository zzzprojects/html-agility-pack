using NUnit.Framework;

namespace HtmlAgilityPack.Tests.fx._4._5
{
    public class HtmlEntityTests
    {
        [Test]
        public void Entitize_PassEmojiUnicode_ShouldCorrectlyEntitize()
        {
            string result = HtmlEntity.Entitize("😂");

            Assert.AreEqual("&#128514;", result);
        }

        [Test]
        public void Entitize_PassSimpleText_ShouldCorrectlyEntitize()
        {
            string result = HtmlEntity.Entitize("qwerty");

            Assert.AreEqual("qwerty", result);
        }
    }
}