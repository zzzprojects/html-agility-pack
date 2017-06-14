using System.IO;
using System.Linq;
using System.Net;
using NUnit.Framework;
using System;

namespace HtmlAgilityPack.Tests
{
	[TestFixture]
	public class HtmlDocumentTests
	{
		private string _contentDirectory;
		
	

		[OneTimeSetUp]
		public void Setup()
		{
            //_contentDirectory = Path.Combine(Environment.CurrentDirectory, @"..\HtmlAgilityPack.Tests\files\");
		    _contentDirectory = Path.Combine(@"C:\Users\Jonathan\Desktop\Z\zzzproject\HtmlAgilityPack\HtmlAgilityPack.Tests\bin\Debug\files\");
        }

		private HtmlDocument GetMshomeDocument()
		{
			var doc = new HtmlDocument();
			doc.Load(_contentDirectory + "mshome.htm");
			return doc;
		}

		[Test]
		public void StackOverflow()
		{
			var url = "http://rewarding.me/active-tel-domains/index.php/index.php?rescan=amour.tel&w=A&url=&by=us&limits=0";
			var request = WebRequest.Create(url);
			var htmlDocument = new HtmlDocument();
			htmlDocument.Load((request.GetResponse()).GetResponseStream());
			Stream memoryStream = new MemoryStream();
			htmlDocument.Save(memoryStream);
		}

		[Test]
		public void CreateAttribute()
		{
			var doc = new HtmlDocument();
			var a = doc.CreateAttribute("href");
			Assert.AreEqual("href", a.Name);
		}

		[Test]
		public void CreateAttributeWithEncodedText()
		{
			var doc = new HtmlDocument();
			var a = doc.CreateAttribute("href", "http://something.com\"&<>");
			Assert.AreEqual("href", a.Name);
			Assert.AreEqual("http://something.com\"&<>", a.Value);
		}

		[Test]
		public void CreateAttributeWithText()
		{
			var doc = new HtmlDocument();
			var a = doc.CreateAttribute("href", "http://something.com");
			Assert.AreEqual("href", a.Name);
			Assert.AreEqual("http://something.com", a.Value);
		}

		//[Test]
		//public void CreateComment()
		//{
		//    var doc = new HtmlDocument();
		//    var a = doc.CreateComment();
		//    Assert.AreEqual(HtmlNode.HtmlNodeTypeNameComment, a.Name);
		//    Assert.AreEqual(a.NodeType, HtmlNodeType.Comment);
		//}

		//[Test]
		//public void CreateCommentWithText()
		//{
		//    var doc = new HtmlDocument();
		//    var a = doc.CreateComment("something");
		//    Assert.AreEqual(HtmlNode.HtmlNodeTypeNameComment, a.Name);
		//    Assert.AreEqual("something", a.InnerText);
		//    Assert.AreEqual(a.NodeType, HtmlNodeType.Comment);
		//}

		[Test]
		public void CreateElement()
		{
			var doc = new HtmlDocument();
			var a = doc.CreateElement("a");
			Assert.AreEqual("a", a.Name);
			Assert.AreEqual(a.NodeType, HtmlNodeType.Element);
		}

		//[Test]
		//public void CreateTextNode()
		//{
		//    var doc = new HtmlDocument();
		//    var a = doc.CreateTextNode();
		//    Assert.AreEqual(HtmlNode.HtmlNodeTypeNameText, a.Name);
		//    Assert.AreEqual(a.NodeType, HtmlNodeType.Text);
		//}

		[Test]
		public void CreateTextNodeWithText()
		{
			var doc = new HtmlDocument();
			var a = doc.CreateTextNode("something");
			Assert.AreEqual("something", a.InnerText);
			Assert.AreEqual(a.NodeType, HtmlNodeType.Text);
		}

		[Test]
		public void HtmlEncode()
		{
			var result = HtmlDocument.HtmlEncode("http://something.com\"&<>");
			Assert.AreEqual("http://something.com&quot;&amp;&lt;&gt;", result);
		}

		[Test]
		public void TestParse()
		{
			var doc = GetMshomeDocument();
			Assert.IsTrue(doc.DocumentNode.Descendants().Count() > 0);
		}

        [Test]
        public void TestLimitDepthParse()
        {
            HtmlAgilityPack.HtmlDocument.MaxDepthLevel = 10;
            var doc = GetMshomeDocument();
            try
            {
                Assert.IsTrue(doc.DocumentNode.Descendants().Count() > 0);
            }
            catch (ArgumentException e)
            {
                Assert.IsTrue(e.Message == HtmlAgilityPack.HtmlNode.DepthLevelExceptionMessage);
            }
            HtmlAgilityPack.HtmlDocument.MaxDepthLevel = int.MaxValue;
        }

        [Test]
		public void TestParseSaveParse()
		{
			var doc = GetMshomeDocument();
			var doc1desc =
				doc.DocumentNode.Descendants().Where(x => !string.IsNullOrWhiteSpace(x.InnerText)).ToList();
			doc.Save(_contentDirectory + "testsaveparse.html");

			var doc2 = new HtmlDocument();
			doc2.Load(_contentDirectory + "testsaveparse.html");
			var doc2desc =
				doc2.DocumentNode.Descendants().Where(x => !string.IsNullOrWhiteSpace(x.InnerText)).ToList();
			Assert.AreEqual(doc1desc.Count, doc2desc.Count);
			//for(var i=0; i< doc1desc.Count;i++)
			//{
			//    try
			//    {
			//        Assert.AreEqual(doc1desc[i].Name, doc2desc[i].Name);
			//    }catch(Exception e)
			//    {
			//        throw;
			//    }
			//}
		}

		[Test]
		public void TestRemoveUpdatesPreviousSibling()
		{
			var doc = GetMshomeDocument();
			var docDesc = doc.DocumentNode.Descendants().ToList();
			var toRemove = docDesc[1200];
			var toRemovePrevSibling = toRemove.PreviousSibling;
			var toRemoveNextSibling = toRemove.NextSibling;
			toRemove.Remove();
			Assert.AreSame(toRemovePrevSibling, toRemoveNextSibling.PreviousSibling);
		}

		[Test]
		public void TestReplaceUpdatesSiblings()
		{
			var doc = GetMshomeDocument();
			var docDesc = doc.DocumentNode.Descendants().ToList();
			var toReplace = docDesc[1200];
			var toReplacePrevSibling = toReplace.PreviousSibling;
			var toReplaceNextSibling = toReplace.NextSibling;
			var newNode = doc.CreateElement("tr");
			toReplace.ParentNode.ReplaceChild(newNode, toReplace);
			Assert.AreSame(toReplacePrevSibling, newNode.PreviousSibling);
			Assert.AreSame(toReplaceNextSibling, newNode.NextSibling);
		}

		[Test]
		public void TestInsertUpdateSiblings()
		{
			var doc = GetMshomeDocument();
			var newNode = doc.CreateElement("td");
			var toReplace = doc.DocumentNode.ChildNodes[2];
			var toReplacePrevSibling = toReplace.PreviousSibling;
			var toReplaceNextSibling = toReplace.NextSibling;
			doc.DocumentNode.ChildNodes.Insert(2, newNode);
			Assert.AreSame(newNode.NextSibling, toReplace);
			Assert.AreSame(newNode.PreviousSibling, toReplacePrevSibling);
			Assert.AreSame(toReplaceNextSibling, toReplace.NextSibling);
		}

	    [Test]
	    public void TestCopyFromNode()
	    {
	        var html = @"<div attr='test'></div>";

	        var htmlDoc = new HtmlDocument();
	        htmlDoc.LoadHtml(html);

	        var divNode = htmlDoc.DocumentNode.SelectSingleNode("//div");

	        var newNode = HtmlAgilityPack.HtmlNode.CreateNode("<body></body>");
	        newNode.CopyFrom(divNode);

	        var attribute1 = divNode.Attributes[0];

	        var attribute2 = newNode.Attributes[0];

	        Assert.AreEqual(divNode.Attributes.Count, newNode.Attributes.Count);
	        Assert.AreEqual(attribute1.Value, attribute2.Value);
	        Assert.AreEqual(attribute1.QuoteType, attribute2.QuoteType);
	    }

	    [Test]
	    public void TestCloneNode()
	    {
	        var html = @"<div attr='test'></div>";

	        var htmlDoc = new HtmlDocument();
	        htmlDoc.LoadHtml(html);

	        var divNode = htmlDoc.DocumentNode.SelectSingleNode("//div");

	        var newNode = divNode.Clone();

	        var attribute1 = divNode.Attributes[0];

	        var attribute2 = newNode.Attributes[0];

	        Assert.AreEqual(divNode.Attributes.Count, newNode.Attributes.Count);
	        Assert.AreEqual(attribute1.Value, attribute2.Value);
	        Assert.AreEqual(attribute1.QuoteType, attribute2.QuoteType);
	    }

	    [Test]
        public void TestEmptyTag()
	    {
	        var html = "<img src=\"x\"/onerror=\"alert('onerror1')\"><img/src=\"x\"/onerror=\"alert('onerror2')\">";
	        var doc = new HtmlAgilityPack.HtmlDocument();
	        doc.LoadHtml(html);

            Assert.AreEqual(@"<img src=""x"" onerror=""alert('onerror1')""><img src=""x"" onerror=""alert('onerror2')"">", doc.DocumentNode.OuterHtml);
        }
		/*
		[Test]
        public void TestAddClass()
        {
            var html = @"<h1>This is new heading</h1>";

            string output = "<h1 class=\"input\">This is new heading</h1>";

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

            h1Node.AddClass("input");

            Assert.AreEqual(h1Node.OuterHtml, output);
        }

        [Test]
        public void TestRemoveClass()
        {
            var output = @"<h1>This is new heading</h1>";

            string html = "<h1 class=\"input\">This is new heading</h1>";

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

            h1Node.RemoveClass("input");

            Assert.AreEqual(h1Node.OuterHtml, output);
        }

        [Test]

        public void TestReplaceClass()
        {
            var output = "<h1 class=\"important\">This is new heading</h1>";

            string html = "<h1 class=\"input\">This is new heading</h1>";

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

            h1Node.ReplaceClass("important", "input");

            Assert.AreEqual(h1Node.OuterHtml, output);
        }
        */
        [Test]

        public void TestDetectEncoding()
        {
            string html = Path.Combine(_contentDirectory, "test.html");

            var htmlDoc = new HtmlDocument();

            var encoding = htmlDoc.DetectEncoding(html);

            Assert.AreEqual(System.Text.Encoding.UTF8, encoding);
        }

	    [Test]
        public void TestLoadWithCache()
	    {
	        var dir = _contentDirectory + "cache";
	        Directory.CreateDirectory(dir);

            var web = new HtmlAgilityPack.HtmlWeb()
	        {
	            CachePath = dir,
	            UsingCache = true
	        };

	        var url = "https://github.com/zzzprojects/html-agility-pack";
	        var docCache = web.Load(url);

            var docLoad = new HtmlAgilityPack.HtmlWeb().Load(url);
	        Console.WriteLine(docLoad.DocumentNode.OuterHtml, docCache.DocumentNode.OuterHtml);
        }
    }
}