using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

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
        public void ScriptingText()
        {
            var html = @"<?xml version=""1.0"" encoding=""UTF-8"" ?>
<html xmlns=""http://www.w3.org/1999/xhtml"">
<head>
    <title>SEE title</title>
	<script>SEE script </script>
	<style>SEE style</style>
</head>
<body>
<script>NOTSEE script</script>
<div>222<script>NOTSEE script</script>
<style>NOTSEE style</style></div>
</body>
</html>";

            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);

                var content1 = htmlDocument.DocumentNode.SelectSingleNode("//head").InnerText;
                var content2 = htmlDocument.DocumentNode.SelectSingleNode("//script").InnerText;
                var content3 = htmlDocument.DocumentNode.SelectSingleNode("//style").InnerText;
                var content4 = htmlDocument.DocumentNode.SelectSingleNode("//body").InnerText;
                var content5 = htmlDocument.DocumentNode.SelectSingleNode("//html").InnerText;
                var content6 = htmlDocument.DocumentNode.SelectSingleNode("//body/script").InnerText;

                Assert.AreEqual("\r\n    SEE title\r\n\tSEE script \r\n\tSEE style\r\n", content1);
                Assert.AreEqual("SEE script ", content2);
                Assert.AreEqual("SEE style", content3);
                Assert.AreEqual("\r\n\r\n222\r\n\r\n", content4);
                Assert.AreEqual("\r\n\r\n    SEE title\r\n\t\r\n\t\r\n\r\n\r\n\r\n222\r\n\r\n\r\n", content5);
                Assert.AreEqual("NOTSEE script", content6);
            }

            {
                HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.BackwardCompatibility = false;
                htmlDocument.LoadHtml(html);

                var content1 = htmlDocument.DocumentNode.SelectSingleNode("//head").InnerText;
                var content2 = htmlDocument.DocumentNode.SelectSingleNode("//script").InnerText;
                var content3 = htmlDocument.DocumentNode.SelectSingleNode("//style").InnerText;
                var content4 = htmlDocument.DocumentNode.SelectSingleNode("//body").InnerText;
                var content5 = htmlDocument.DocumentNode.SelectSingleNode("//html").InnerText;
                var content6 = htmlDocument.DocumentNode.SelectSingleNode("//body/script").InnerText;

                Assert.AreEqual("    SEE titleSEE script SEE style", content1);
                Assert.AreEqual("SEE script ", content2);
                Assert.AreEqual("SEE style", content3);
                Assert.AreEqual("222", content4);
                Assert.AreEqual("    SEE title222", content5);
                Assert.AreEqual("NOTSEE script", content6);
            }
        }

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

	    [Test]
	    public void OptionMaxNestedChildNodes_NotSet_IsNotEnforced()
	    {
		    var html = "<html><body><div>1<div>2</div>3</div></body></html>";
		    var doc = new HtmlDocument();

		    doc.LoadHtml(html);

		    Assert.IsNotNull(doc);
		    Assert.AreEqual(html, doc.Text);
	    }

	    [Test]
	    public void OptionMaxNestedChildNodes_SetToZero_IsNotEnforced()
	    {
		    var html = "<html><body><div>1<div>2</div>3</div></body></html>";
		    var doc = new HtmlDocument();
		    doc.OptionMaxNestedChildNodes = 0;

		    doc.LoadHtml(html);

		    Assert.IsNotNull(doc);
		    Assert.AreEqual(html, doc.Text);
	    }

	    [Test]
	    public void OptionMaxNestedChildNodes_WithinMax_NoException()
	    {
		    var html = "<div id='1'><div id='2'><div id='3'><div id='4'><div id='5'><div id='6'><div id='7'><div id='8'></div></div></div></div></div></div></div></div>";
		    var doc = new HtmlDocument();
		    doc.OptionMaxNestedChildNodes = 8;

		    doc.LoadHtml(html);
	    }

	    [Test]
	    [ExpectedException(typeof(ApplicationException))]
	    public void OptionMaxNestedChildNodes_AbotMax()
	    {
		    var html = "<div id='1'><div id='2'><div id='3'><div id='4'><div id='5'><div id='6'><div id='7'><div id='8'></div></div></div></div></div></div></div></div>";
		    var doc = new HtmlDocument();
		    doc.OptionMaxNestedChildNodes = 7;
		    string message = "";
		    try
			{
				doc.LoadHtml(html); 
			}
		    catch (Exception e)
		    {
			    message = e.Message; 
		    }

			Assert.AreEqual("Document has more than 7 nested tags. This is likely due to the page not closing tags properly.", message);
	    }
	}
}