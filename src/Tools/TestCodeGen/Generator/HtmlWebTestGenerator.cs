using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace TestCodeGen.Generator
{
    public class HtmlWebTestGenerator : TestCodeGenerator
    {
        public override string MenuItemName => "Generate a test for HtmlWeb class mocking the web request.";

        #region Inner Classes

        class DummyException : Exception
        {
        }

        #endregion

        #region Parameter Loaders

        class UrlParamLoader : ParamLoader
        {
            public override string Message
                => "Enter a URL";

            public UrlParamLoader(TestCodeGenerator generator) : base(generator) { }

            public override void SetUp(string input)
            {
                try
                {
                    ((HtmlWebTestGenerator)Generator).Url = new Uri(input);
                }
                catch (UriFormatException e)
                {
                    throw new Exception("The entered URL was invalid.", e);
                }
            }
        }

        class OutputContentParamLoader : ParamLoader
        {
            public override string Message
                => "Does the test need response content? [Yes|No] (default: Yes)";

            public OutputContentParamLoader(TestCodeGenerator generator) : base(generator) { }

            public override void SetUp(string input)
            {
                switch (input.Trim().ToLower())
                {
                    case "no":
                    case "n":
                        ((HtmlWebTestGenerator)Generator).OutputContent = false;
                        return;
                }
                ((HtmlWebTestGenerator)Generator).OutputContent = true;
            }
        }

        #endregion

        public Uri Url { get; private set; }
        public bool OutputContent { get; private set; }

        public HtmlWebTestGenerator()
        {
            _paramLoaders.Add(new OutputContentParamLoader(this));
            _paramLoaders.Add(new UrlParamLoader(this));
        }

        public override IEnumerable<TestCode> Generate()
        {
            var code4StatusCode = "";
            var code4ContentType = "";
            var code4ContentEncoding = "";
            var code4Headers = "";
            var code4Content = "";
            string content = null;

            var htmlWeb = new HtmlWeb();
            htmlWeb.PostResponse += (HttpWebRequest req, HttpWebResponse res) =>
            {
                // generate code for mocking IHttpWebResponse.StatusCode property
                code4StatusCode = $@"{Indent(6)}resMock.Setup(x => x.StatusCode).Returns({typeof(HttpStatusCode).Name}.{res.StatusCode.ToString()});";

                // generate code for mocking IHttpWebResponse.ContentType property
                code4ContentType = $@"{Indent(6)}resMock.Setup(x => x.ContentType).Returns(""{res.ContentType}"");";

                // generate code for mocking IHttpWebResponse.ContentEncoding property
                code4ContentEncoding = $@"{Indent(6)}resMock.Setup(x => x.ContentEncoding).Returns(""{res.ContentEncoding}"");";

                // generate code for mocking IHttpWebResponse.Headers property
                var headers = res.Headers;
                code4Headers = headers.AllKeys
                    .Select(k => $"{Indent(7)}headers.Add(\"" + k + "\", \"" + headers[k].Replace("\"", "\\\"") + "\");")
                    .DefaultIfEmpty()
                    .Aggregate((a, b) => $"{a}{Environment.NewLine}{b}");

                code4Headers = $@"{Indent(6)}resMock.Setup(x => x.Headers).Returns(() =>
{Indent(6)}{{
{Indent(7)}var headers = new WebHeaderCollection();
{code4Headers}
{Indent(7)}return headers;
{Indent(6)}}});";

                // generate code for mocking IHttpWebResponse.GetResponseStream() method
                if (OutputContent)
                {
                    using (var s = res.GetResponseStream())
                    {
                        Encoding encoding;
                        try
                        {
                            encoding = Encoding.GetEncoding(res.ContentEncoding);
                        }
                        catch (ArgumentException)
                        {
                            encoding = Encoding.UTF8;
                        }
                        var r = new StreamReader(s, encoding);
                        content = r.ReadToEnd();
                    }

                    code4Content = $@"{Indent(6)}resMock.Setup(x => x.GetResponseStream())
{Indent(7)}.Returns(() => new FileStream(
{Indent(8)}Path.Combine(_contentDir, ""{TestName}.html""),
{Indent(8)}FileMode.Open,
{Indent(8)}FileAccess.Read));";
                }
                else
                {
                    code4Content = $@"{Indent(6)}resMock.Setup(x => x.GetResponseStream()).Returns(
{Indent(7)}() => new MemoryStream());";
                }

                throw new DummyException();
            };

            try
            {
                htmlWeb.Load(Url);
            }
            catch (DummyException)
            {
            }

            var regexNewLine = new Regex("(\n\r?)|(\r\n)");
            yield return new TestCode
                {
                    File = new FileInfo(Path.Combine(OutDir.ToString(), TestName + ".cs")),
                    Content = regexNewLine.Replace($@"using System;
using System.IO;
using System.Net;
using Moq;
using NUnit.Framework;

namespace HtmlAgilityPack.Tests
{{
{Indent(1)}[TestFixture]
{Indent(1)}class {TestName}
{Indent(1)}{{
{Indent(2)}private string _contentDir;

{Indent(2)}[OneTimeSetUp]
{Indent(2)}public void Setup()
{Indent(2)}{{
{Indent(3)}_contentDir = Path.Combine(
{Indent(4)}Path.GetDirectoryName(typeof(HtmlDocumentTests).Assembly.Location),
{Indent(4)}""files"");
{Indent(2)}}}

{Indent(2)}[Test]
{Indent(2)}public void Test()
{Indent(2)}{{
{Indent(3)}var factoryMock = new Mock<IHttpWebRequestFactory>();
{Indent(3)}factoryMock.Setup(x => x.Create(It.IsAny<Uri>()))
{Indent(4)}.Returns<Uri>(u =>
{Indent(4)}{{
{Indent(5)}var reqMock = new Mock<IHttpWebRequest>();
{Indent(5)}reqMock.Setup(x => x.Request).Returns(null as HttpWebRequest);
{Indent(5)}reqMock.Setup(x => x.GetResponse()).Returns(() =>
{Indent(5)}{{
{Indent(6)}var resMock = new Mock<IHttpWebResponse>();
{Indent(6)}resMock.Setup(x => x.ResponseUri).Returns(u);
{code4StatusCode}
{code4ContentType}
{code4ContentEncoding}
{code4Headers}
{code4Content}
{Indent(6)}resMock.Setup(x => x.LastModified).Returns(DateTime.UtcNow);
{Indent(6)}return resMock.Object;
{Indent(5)}}});
{Indent(5)}return reqMock.Object;
{Indent(4)}}});

{Indent(3)}var htmlWeb = new HtmlWeb(factoryMock.Object);
{Indent(3)}htmlWeb.Load(new Uri(""{Url.OriginalString}""));
{Indent(2)}}}
{Indent(1)}}}
}}
", Environment.NewLine),
            };

            if (OutputContent)
                yield return new TestCode
                {
                    File = new FileInfo(Path.Combine(OutDir.ToString(), "files", TestName + ".html")),
                    Content = content,
                };
        }

        public string Indent(int count)
        {
            return new string(' ', 4 * count);
        }
    }
}
