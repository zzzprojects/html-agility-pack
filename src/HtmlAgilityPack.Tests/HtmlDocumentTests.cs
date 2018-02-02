using System.IO;
using System.Linq;
using System.Net;
using NUnit.Framework;
using System;
using System.Globalization;
using System.Threading;

namespace HtmlAgilityPack.Tests
{
    [TestFixture]
    public class HtmlDocumentTests
    {
        private string _contentDirectory;



        [OneTimeSetUp]
        public void Setup()
        {
             

            _contentDirectory = Path.GetDirectoryName(typeof(HtmlDocumentTests).Assembly.Location).ToString() + "\\files\\";
            //   _contentDirectory = Path.Combine(@"C:\Users\Jonathan\Desktop\Z\zzzproject\HtmlAgilityPack\HtmlAgilityPack.Tests\bin\Debug\files\");
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
            // url not work, ???? 
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

            Assert.AreEqual(doc.DocumentNode.OuterHtml, html);
        }

        [Test]
        public void TestLoadWithUri()
        {
            //string adress = "http://www.filmweb.pl/film/Piraci+z+Karaib%C3%B3w%3A+Zemsta+Salazara-2017-606542";
            //Uri uri = new Uri(adress, true);
            //var web = new HtmlWeb();
            //HtmlAgilityPack.HtmlDocument document = web.Load(uri);
            //Assert.AreNotEqual(string.Empty, document.DocumentNode.OuterHtml);
        }

        [Test]
        public void TestFormTag()
        {
            var html = @"<form></form>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var result = document.DocumentNode.Descendants().Select(dn => new {dn.NodeType, dn.Name, dn.OuterHtml}).ToArray();
            Assert.AreEqual(html, document.DocumentNode.OuterHtml);
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void TestNumericTag()
        {
            var html = @"<div><1</div>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var result = document.DocumentNode.Descendants().Select(dn => new {dn.NodeType, dn.Name, dn.OuterHtml}).ToArray();
            Assert.AreEqual(html, document.DocumentNode.OuterHtml);
        }

        [Test]
        public void ImplicitTag()
        {
            {
                var html = @"<dt>a<dd>b<dd>c<dt>a<dd>b<dd>c";
                var document = new HtmlDocument();
                document.LoadHtml(html);
                var result = document.DocumentNode.Descendants().Select(dn => new {dn.NodeType, dn.Name, dn.OuterHtml}).ToArray();

                // TODO: Fix issue with last "dd"
                Assert.AreEqual(html + "</dd>", document.DocumentNode.OuterHtml);
            }


            {
                var html = @"<dt>a</dt><dd>b</dd><dd>c</dd><dt>a</dt><dd>b</dd><dd>c</dd>";
                var document = new HtmlDocument();
                document.LoadHtml(html);
                var result = document.DocumentNode.Descendants().Select(dn => new {dn.NodeType, dn.Name, dn.OuterHtml}).ToArray();

                Assert.AreEqual(html, document.DocumentNode.OuterHtml);
            }
        }

        [Test]
        public void DeEntitize()
        {
            var html = @"mouse&apos;s house";

            Assert.AreEqual("mouse's house", HtmlEntity.DeEntitize("mouse&apos;s house"));
        }

        [Test]
        public void InnerText_Comment()
        {
            var document = new HtmlDocument();
            document.LoadHtml("<p><!-- comment 1 -->Expected <!-- comment 2 -->value</p>");

            Assert.AreEqual("Expected value", document.DocumentNode.FirstChild.InnerText);
        }

        [Test]
        public void TestFixNestedAnchors()
        {
            var inHtml = "<html><body><a href='...'> Here's a great link! <a href='...'>Here's another one!</a>Here's some unrelated text.</body></html>";
            var expectedHtml = "<html><body><a href='...'> Here's a great link! <a href='...'>Here's another one!</a>Here's some unrelated text.</body></html>";

            var doc = new HtmlDocument();
            doc.LoadHtml(inHtml);

            Assert.AreEqual(expectedHtml, doc.DocumentNode.OuterHtml);
        }

        [Test]
        public void TestInnerText()
        {
            var inHtml = @"<html>
	<head>
		<title>
			InnerText bug Demo
		</title>
	</head>
	<body>
		<div>
			This demonstration should show that the HAP currently parses div tags incorrectly, parsing carriage returns, new lines and tabular indents as text.
		</div>
	</body>
</html>";
            var expectedHtml = "InnerText bug DemoThis demonstration should show that the HAP currently parses div tags incorrectly, parsing carriage returns, new lines and tabular indents as text.";

            var doc = new HtmlDocument() {BackwardCompatibility = false};
            doc.LoadHtml(inHtml);

            Assert.AreEqual(expectedHtml, doc.DocumentNode.InnerText);
        }

        [Test]
        public void TestOptionTag()
        {
            var html = "<select><option>Select a cell</option><option>C1</option><option value='\"c2\"'></select>";

            string output = "<select><option>Select a cell</option><option>C1</option><option value='\"c2\"'></option></select>";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            Assert.AreEqual(output, document.DocumentNode.OuterHtml);
        }

        [Test]
        public void VerifyChildDivParent()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml("<html><body></body></html>");

            var div = HtmlNode.CreateNode("<div class='1'/>");
            var div2 = HtmlNode.CreateNode("<div class='2'/>");

            doc.DocumentNode.ChildNodes.Add(div);
            div.ChildNodes.Add(div2);

            Assert.AreEqual(div.Name, div2.ParentNode.Name);

        }


        [Test]
        public void ChildIsRemovedFromParent()
        {
            var doc = new HtmlDocument();
            doc.LoadHtml("<html><body></body></html>");

            var div = HtmlNode.CreateNode("<div class='1'/>");
            var div2 = HtmlNode.CreateNode("<div class='2'/>");

            div.ChildNodes.Add(div2);
            doc.DocumentNode.ChildNodes.Add(div);


            div.FirstChild.Remove();

            Assert.AreEqual(0, div.ChildNodes.Count);

        }

        [Test]
        public void CompareLowerCulture()
        {

            string html = File.ReadAllText(_contentDirectory + "regression.html");
            HtmlNode node1 = null;
            // Test 1
            CultureInfo cul1 = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = cul1;
            HtmlAgilityPack.HtmlDocument doc1 = new HtmlAgilityPack.HtmlDocument();
            doc1.LoadHtml(html);

            node1 = doc1.DocumentNode.SelectSingleNode("//div[@id='mainContents']/h2");

            CultureInfo cul2 = CultureInfo.CreateSpecificCulture("tr-TR");
            Thread.CurrentThread.CurrentCulture = cul2;
            HtmlAgilityPack.HtmlDocument doc2 = new HtmlAgilityPack.HtmlDocument();
            doc2.LoadHtml(html);
            var s = doc2.DocumentNode.OuterHtml;

            HtmlNode node2 = doc2.DocumentNode.SelectSingleNode("//div[@id='mainContents']/h2");
            if (node1?.InnerHtml == node2?.InnerHtml)

                 
            Assert.AreEqual(node1?.InnerHtml, node2?.InnerHtml);
            Assert.AreEqual(0, doc2.DocumentNode.OwnerDocument.ParseErrors.Count());
        }


        [Test]
        public void OverFlowNotEndTag()
        {

            string html = File.ReadAllText(_contentDirectory + "overflow.html");
            HtmlNode node1 = null;
            // Test 1
             
            HtmlAgilityPack.HtmlDocument doc1 = new HtmlAgilityPack.HtmlDocument();
            doc1.LoadHtml(html);

            Assert.AreEqual(15, doc1.DocumentNode.ChildNodes[4].ChildNodes.Count);

            Assert.AreEqual(0, doc1.DocumentNode.OwnerDocument.ParseErrors.Count());
        }
    }
}