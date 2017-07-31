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
        public void TestEmptyTag_Single()
        {
            var html = "<img src=\"x\"/onerror=\"alert('onerror1')\"><img/src=\"x\"/onerror=\"alert('onerror2')\">";
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            Assert.AreEqual(@"<img src=""x"" onerror=""alert('onerror1')""><img src=""x"" onerror=""alert('onerror2')"">", doc.DocumentNode.OuterHtml);
        }

        [Test]
        public void TestEmptyTag_Many()
        {
            {
                var html = "<img src=\"x\"//onerror=\"alert('onerror1')\"><img//src=\"x\"//onerror=\"alert('onerror2')\">";
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                Assert.AreEqual(@"<img src=""x"" onerror=""alert('onerror1')""><img src=""x"" onerror=""alert('onerror2')"">", doc.DocumentNode.OuterHtml);
            }

            {
                var html = "<img src=\"x\"//////onerror=\"alert('onerror1')\"><img//////////////src=\"x\"////////////////onerror=\"alert('onerror2')\">";
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);

                Assert.AreEqual(@"<img src=""x"" onerror=""alert('onerror1')""><img src=""x"" onerror=""alert('onerror2')"">", doc.DocumentNode.OuterHtml);
            }
        }

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

            var url = "http://html-agility-pack.net/";
            var docCache = web.Load(url);

            var docLoad = new HtmlAgilityPack.HtmlWeb().Load(url);
            Assert.AreEqual(docLoad.DocumentNode.OuterHtml, docCache.DocumentNode.OuterHtml);
        }

        [Test]
        public void OuterHtmlHasBeenCalled_RemoveCalled_SubsequentOuterHtmlCallsAreBroken()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml("<html><head></head><body><div>SOme text here</div><div>some bolded<b>text</b></div></body></html>");
            var resultList = doc.DocumentNode.SelectNodes("//div");
            Assert.AreEqual(2, resultList.Count);
            resultList.First().Remove();
            Assert.AreEqual("<html><head></head><body><div>some bolded<b>text</b></div></body></html>", doc.DocumentNode.OuterHtml);
            var resultList2 = doc.DocumentNode.SelectNodes("//div");
            Assert.AreEqual(1, resultList2.Count);
            resultList2.First().Remove();
            // <div>some bolded<b>text</b></div> should have been removed
            Assert.AreEqual("<html><head></head><body></body></html>", doc.DocumentNode.OuterHtml);
        }

        [Test]
        public void TestAttributeDeEntitizeValue()
        {
            var html =
                "<!DOCTYPE html><html><body data-foo=&quot;Hello&quot;><p>This is <u>underlined</u> paragraph</p></body></html>";

            string output = "\"Hello\"";

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var body = htmlDoc.DocumentNode.SelectSingleNode("//body");

            var val = body.Attributes["data-foo"].DeEntitizeValue;

            Assert.AreEqual(output, val);
        }

        [Test]
        public void TestAttributeDeEntitizeValue2()
        {
            var html =
                "<!DOCTYPE html><html><body data-foo=&quot;\"Hello\"&quot;><p>This is <u>underlined</u> paragraph</p></body></html>";

            string output = "\"\"Hello\"\"";

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var body = htmlDoc.DocumentNode.SelectSingleNode("//body");

            var val = body.Attributes["data-foo"].DeEntitizeValue;

            Assert.AreEqual(output, val);
        }

        [Test]
        public void TestAttributeDeEntitizeValue3()
        {
            var doc = new HtmlDocument();
            var a = doc.CreateAttribute("href", "\"bad_href\"");
            Assert.AreEqual("href", a.Name);
            Assert.AreEqual("\"bad_href\"", a.DeEntitizeValue);
        }

        [Test]
        public void TestAttributeDeEntitizeValue4()
        {
            var html = "<!DOCTYPE html><html><body data-foo='\"Hello\"'><p>This is <u>underlined</u> paragraph</p></body></html>";

            string output = "\"Hello\"";

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var body = htmlDoc.DocumentNode.SelectSingleNode("//body");

            var val = body.Attributes["data-foo"].DeEntitizeValue;

            Assert.AreEqual(output, val);
        }

        [Test]
        public void TestAttributeValue()
        {
            var html = @"<!DOCTYPE html><html><body data-foo='http://example.com/path?productId=9788762505032&amp;title=something'><p>This is <u>underlined</u> paragraph</p></body></html>";

            string output = "http://example.com/path?productId=9788762505032&amp;title=something";

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            var body = htmlDoc.DocumentNode.SelectSingleNode("//body");

            var val = body.Attributes["data-foo"].Value;

            Assert.AreEqual(output, val);
        }

        [Test]

        public void TestSingleNodesEmptyCollection()
        {
            var html =
                @"<!DOCTYPE html>
<html>
<body>
	<h1>This is <b>bold</b> heading</h1>
	<p>This is <u>underlined</u> paragraph</p>
	<h2>This is <i>italic</i> heading</h2>
	<h2>This is new heading</h2>
</body>
</html> ";

            var output = 0;

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            htmlDoc.OptionEmptyCollection = true;

            var divNodes = htmlDoc.DocumentNode.SelectNodes("//div");

            Assert.AreEqual(output, divNodes.Count);
        }

        [Test]
        public void TestCreateNode()
        {
            string output = "<p>text</p>";
            HtmlNode node1 = HtmlNode.CreateNode(@"
            <p>text</p>
            ");

            HtmlNode node2 = HtmlNode.CreateNode(@"
                         
            <p>text</p>            

            ");

            HtmlNode node3 = HtmlNode.CreateNode(@"   <p>text</p>   ");

            Assert.AreEqual(output, node1.OuterHtml);
            Assert.AreEqual(output, node2.OuterHtml);
            Assert.AreEqual(output, node3.OuterHtml);

            try
            {
                HtmlNode node4 = HtmlNode.CreateNode("<p>a<p/><p>b</p>");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Multiple node elments can't be created.", e.Message);
            }

            HtmlNode node5 = HtmlNode.CreateNode(@"/r/n");
            Assert.AreEqual("/r/n", node5.OuterHtml);
        }

        [Test]
        public void TestParseListInList()
        {
            var html = "<ol><li><ol><li>x</li></ol></li></ol>";

            var doc = new HtmlDocument();
            doc.OptionFixNestedTags = true;
            doc.Load(new StringReader(html));

            Assert.AreEqual(html, doc.DocumentNode.OuterHtml);
        }

        [Test]
        public void TestLoadWithUri()
        {
            string adress = "http://www.filmweb.pl/film/Piraci+z+Karaib%C3%B3w%3A+Zemsta+Salazara-2017-606542";
            Uri uri = new Uri(adress, true);
            var web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load(uri);
            Assert.AreNotEqual(document.DocumentNode.OuterHtml, string.Empty);
        }

        [Test]
        public void TestFormTag()
        {
            var html = @"<form></form>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var result = document.DocumentNode.Descendants().Select(dn => new { dn.NodeType, dn.Name, dn.OuterHtml }).ToArray();
            Assert.AreEqual(document.DocumentNode.OuterHtml, html);
            Assert.AreEqual(result.Count(), 1);
        }
        [Test]
        public void TestOptionTag()
        {
            var html = "<select><option>Select a cell</option><option>C1</option><option value='\"c2\"'></select>";

            string output = "<select><option>Select a cell</option><option>C1</option><option value='\"c2\"'></option></select>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            Assert.AreEqual(document.DocumentNode.OuterHtml, output);
        }
    }
}