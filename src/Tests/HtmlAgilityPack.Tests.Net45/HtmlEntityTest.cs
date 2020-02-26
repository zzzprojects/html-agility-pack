using System;
using NUnit.Framework;

namespace HtmlAgilityPack.Tests
{
    class HtmlEntityTest
    {
        [Test]
        public void Entitize_PassEmojiUnicode_ShouldCorrectlyEntitize()
        {
            try
            {
                HtmlEntity.UseWebUtility = true;
                string result = HtmlEntity.Entitize("😂");

                Assert.AreEqual("&#128514;", result);
            }
            finally
            {
                HtmlEntity.UseWebUtility = false;
            }
       
        }

        [Test]
        public void Entitize_PassSimpleText_ShouldCorrectlyEntitize()
        {
            try
            {
                HtmlEntity.UseWebUtility = true;
                string result = HtmlEntity.Entitize("qwerty");

                Assert.AreEqual("qwerty", result);
            }
            finally
            {
                HtmlEntity.UseWebUtility = false;
            }
        }
    }
}
