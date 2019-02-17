using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace HtmlAgilityPack.Tests
{
    [TestFixture]
    public class HtmlNode2
    {
        //[Test(Description =
        //    "Attributes should maintain their original character casing if OptionOutputOriginalCase is true")]
        //public void EnsureAttributeOriginalCaseIsPreserved()
        //{
        //    var html = "<html><body><div AttributeIsThis=\"val\"></div></body></html>";
        //    var doc = new HtmlDocument
        //    {
        //        OptionOutputOriginalCase = true
        //    };
        //    doc.LoadHtml(html);
        //    var div = doc.DocumentNode.Descendants("div").FirstOrDefault();
        //    var writer = new StringWriter();
        //    div.WriteAttributes(writer, false);
        //    var result = writer.GetStringBuilder().ToString();
        //    Assert.AreEqual(" AttributeIsThis=\"val\"", result);
        //}

        [Test]
        public void ReadNotCloseTag()
        {
            var document = new HtmlDocument();
            document.LoadHtml("<ul><li>item<span></li></ul>");
            var span = document.DocumentNode.SelectSingleNode("//span");
            if (span == null) throw new Exception("Failed to find span element");
            var OuterHtml = span.OuterHtml;
            var InnerHtml = span.InnerHtml;
            var InnerText = span.InnerText;
            
            Assert.IsNotNull(OuterHtml);
            Assert.IsNotNull(InnerHtml);
            Assert.IsNotNull(InnerText);
        }


	    [Test]
	    public void checkAttributForTextComment()
	    {
		    var doc = new HtmlAgilityPack.HtmlDocument();
		    doc.LoadHtml(@"<html><body><div id='foo'><span> some</span> text</div></body></html>");
		    var div = doc.GetElementbyId("foo");
		    int count = 0;
		    Exception exception = null;
		    foreach (var textNode in div.ChildNodes)
		    {
			    try
			    {
				    textNode.Id = "1";
				    count++;
			    }
			    catch (Exception e)
			    {
				    exception = e;

			    }
		    }

		    Assert.AreEqual(count, 1);
		    Assert.IsNotNull(exception);
	    }


	    [Test]
	    public void Prepend_CheckOrder()
	    {
			HtmlNode source = HtmlNode.CreateNode(@"
<ul>
  <li> Alpha   </li>
  <li> Bravo   </li>
  <li> Charlie </li>
</ul>
");
		    HtmlNode destination = HtmlNode.CreateNode(@"
<ul>
  <li> Delta   </li>
  <li> Echo    </li>
  <li> Foxtrot </li>
</ul>
");

		    destination.PrependChildren(source.ChildNodes); 
		 
			Assert.AreEqual(destination.WriteTo()
				, @"<ul>
  <li> Alpha   </li>
  <li> Bravo   </li>
  <li> Charlie </li>

  <li> Delta   </li>
  <li> Echo    </li>
  <li> Foxtrot </li>
</ul>"); 
	    }
	}
}