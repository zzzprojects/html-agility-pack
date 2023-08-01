using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace HtmlAgilityPack.Tests.NetStandard2_0
{
    [HasXPath]
    [DebuggerDisplay("{Title}")]
    public class EncapsulationTestHtml
    {
        public const string Html = @"
<html>
<head>
<title>Test</title>
</head>
<body>
<h1>Test</h1>
<a class='link' href='link1.html'>Link 1</a>
<a class='link' href='link2.html'>Link 2</a>
<a class='link' href='link3.html'>Link 3</a>
<div class='form'>
<form>
<input name='username' value='test' />
<input name='password' value='test' />
<input name='email' value='' />
<input name='email2' value='' />
</form>
</div>
<article id='9718'>
<h2><a href='/article1'>Article 1</a> </h2>
<div><span title='2021-09-23 23:22:01'>3 seconds ago</span></div>
<p>Content 1</p>
</article>
<article id='2312'>
<h2><a href='/article2'>Article 2</a> </h2>
<p>Content 2</p>
</article>
";
        [XPath("//head/title")]
        public string Title { get; set; } = null!;

        [XPath("//h1")]
        public string H1 { get; set; } = null!;

        [XPath("//a[@class='link'][1]")]
        public string Link1 { get; set; } = null!;

        [XPath("//a[@class='link'][2]")]
        [SkipNodeNotFound]
        public string? Link2 { get; set; }

        [XPath("//a[@class='link'][3]", ReturnType.OuterHtml)]
        [SkipNodeNotFound]
        public Link? Link3 { get; set; }

        [XPath("//div/form")]
        public FormName? Form { get; set; }

        [XPath("//article", ReturnType.OuterHtml)]
        public List<Article> Articles { get; set; } = new List<Article>();

        [HasXPath]
        [DebuggerDisplay("{Text}/{Href}")]
        public class Link
        {
            [XPath("a")]
            public string Text { get; set; } = null!;

            [XPath("a", "href")]
            public string Href { get; set; } = null!;
        }

        [HasXPath]
        [DebuggerDisplay("{UserName}")]
        public class FormName
        {
            [XPath("input[1]", "name")]
            public string UserName { get; set; } = null!;

            [XPath("input[2]", "name")]
            public string Password { get; set; } = null!;
            [XPath("input[3]", "name")]
            public string Email { get; set; } = null!;
            [XPath("input[4]", "name")]
            public string Email2 { get; set; } = null!;
        }


        [HasXPath]
        [DebuggerDisplay("{Id}/{Title}")]
        public class Article
        {
            [XPath("article", "id")]
            public string Id { get; set; } = null!;
            [XPath("article/h2/a", ReturnType.OuterHtml)]
            public Link Title { get; set; } = null!;

            [XPath("article/div/span", "title")]
            [SkipNodeNotFound]
            public DateTime Created { get; set; }

            [XPath("article/div/span")]
            [SkipNodeNotFound]
            public string? CreatedText { get; set; } = null!;
            [XPath("article/p")]
            public string? Content { get; set; }
        }
    }
}
