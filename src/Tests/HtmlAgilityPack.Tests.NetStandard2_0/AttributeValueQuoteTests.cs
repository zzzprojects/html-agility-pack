using System.IO;
using System.Linq;
using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using Xunit;
using System.Xml.Linq;

namespace HtmlAgilityPack.Tests.NetStandard2_0
{

    public class AttributeValueQuoteTests
    {
        public static string GlobalHtml1 = "<div singlequote='value' doublequote=\"value\" none=value withoutvalue></div>";

        [Fact]
        public void GlobalAttributeValueQuote_DoubleQuote()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.DoubleQuote;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<div singlequote=\"value\" doublequote=\"value\" none=\"value\" withoutvalue=\"\"></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_SingleQuote()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.SingleQuote;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<div singlequote='value' doublequote='value' none='value' withoutvalue=''></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_WithoutValue()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.WithoutValue;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<div singlequote doublequote none withoutvalue></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_Initial()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.Initial;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<div singlequote='value' doublequote=\"value\" none=value withoutvalue></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_InitialExceptWithoutValue()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.InitialExceptWithoutValue;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<div singlequote='value' doublequote=\"value\" none=value withoutvalue=\"\"></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_None()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.None;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<div singlequote=value doublequote=value none=value withoutvalue=></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_DoubleQuote_OutputAsXml()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.DoubleQuote;
            doc.OptionOutputAsXml = true;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?><div singlequote=\"value\" doublequote=\"value\" none=\"value\" withoutvalue=\"\"></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_SingleQuote_OutputAsXml()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.SingleQuote;
            doc.OptionOutputAsXml = true;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?><div singlequote='value' doublequote='value' none='value' withoutvalue=''></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_WithoutValue_OutputAsXml()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.WithoutValue;
            doc.OptionOutputAsXml = true;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?><div singlequote=\"value\" doublequote=\"value\" none=\"value\" withoutvalue=\"\"></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_Initial_OutputAsXml()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.Initial;
            doc.OptionOutputAsXml = true;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?><div singlequote='value' doublequote=\"value\" none=\"value\" withoutvalue=\"\"></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_InitialExceptWithoutValue_OutputAsXml()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.InitialExceptWithoutValue;
            doc.OptionOutputAsXml = true;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?><div singlequote='value' doublequote=\"value\" none=\"value\" withoutvalue=\"\"></div>", doc.DocumentNode.OuterHtml);
        }

        [Fact]
        public void GlobalAttributeValueQuote_None_OutputAsXml()
        {
            var doc = new HtmlDocument();
            doc.GlobalAttributeValueQuote = AttributeValueQuote.None;
            doc.OptionOutputAsXml = true;
            doc.LoadHtml(GlobalHtml1);

            Assert.Equal("<?xml version=\"1.0\" encoding=\"utf-8\"?><div singlequote=\"value\" doublequote=\"value\" none=\"value\" withoutvalue=\"\"></div>", doc.DocumentNode.OuterHtml);
        }
    }
}