using System;
using System.Collections.Generic;
using Xunit;

namespace HtmlAgilityPack.Tests.NetStandard2_0
{
    public class HtmlNode_GetEncapsulatedData_NodeReturnType_Tests
    {
        [Theory]
        [InlineData(typeof(Model_InvalidReturnTypeOnElementWithStringProperty))]
        [InlineData(typeof(Model_InvalidReturnTypeAsNamedArgOnElementWithStringProperty))]
        public void InvalidReturnTypeOnElementWithStringProperty(Type modelType)
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var ex = Assert.Throws<InvalidNodeReturnTypeException>(
                () => doc.DocumentNode.GetEncapsulatedData(modelType)
            );

            Assert.Equal("Invalid ReturnType value 1234", ex.Message);
        }

        [HasXPath]
        class Model_InvalidReturnTypeOnElementWithStringProperty
        {
            [XPath("//div/a", (ReturnType) 1234)]
            public string? StringValue { get; set; }
        }

        [HasXPath]
        class Model_InvalidReturnTypeAsNamedArgOnElementWithStringProperty
        {
            [XPath("//div/a", NodeReturnType = (ReturnType) 1234)]
            public string? StringValue { get; set; }
        }


        [Fact]
        public void ImplicitReturnTypeOnElementWithStringProperty()
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var model = doc.DocumentNode.GetEncapsulatedData<Model_ImplicitReturnTypeOnElementWithStringProperty>();

            Assert.NotNull(model);
            Assert.Equal("Link 1", model.StringValue);
        }

        [HasXPath]
        class Model_ImplicitReturnTypeOnElementWithStringProperty
        {
            [XPath("//div/a")]
            public string? StringValue { get; set; }
        }


        [Theory]
        [InlineData(typeof(Model_ReturnTypeInnerTextOnElementWithStringProperty))]
        [InlineData(typeof(Model_ReturnTypeInnerTextAsNamedArgOnElementWithStringProperty))]
        public void ReturnTypeInnerTextOnElementWithStringProperty(Type modelType)
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var model = (IModelWithStringProperty) doc.DocumentNode.GetEncapsulatedData(modelType);

            Assert.NotNull(model);
            Assert.Equal("Link 1", model.StringValue);
        }

        [HasXPath]
        class Model_ReturnTypeInnerTextOnElementWithStringProperty : IModelWithStringProperty
        {
            [XPath("//div/a", ReturnType.InnerText)]
            public string? StringValue { get; set; }
        }

        [HasXPath]
        class Model_ReturnTypeInnerTextAsNamedArgOnElementWithStringProperty : IModelWithStringProperty
        {
            [XPath("//div/a", NodeReturnType = ReturnType.InnerText)]
            public string? StringValue { get; set; }
        }


        [Theory]
        [InlineData(typeof(Model_ReturnTypeInnerHTMLOnElementWithStringProperty))]
        [InlineData(typeof(Model_ReturnTypeInnerHTMLAsNamedArgOnElementWithStringProperty))]
        public void ReturnTypeInnerHTMLOnElementWithStringProperty(Type modelType)
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var model = (IModelWithStringProperty) doc.DocumentNode.GetEncapsulatedData(modelType);

            Assert.NotNull(model);
            Assert.Equal("<h1>Link 1</h1>", model.StringValue);
        }

        [HasXPath]
        class Model_ReturnTypeInnerHTMLOnElementWithStringProperty : IModelWithStringProperty
        {
            [XPath("//div/a", ReturnType.InnerHtml)]
            public string? StringValue { get; set; }
        }

        [HasXPath]
        class Model_ReturnTypeInnerHTMLAsNamedArgOnElementWithStringProperty : IModelWithStringProperty
        {
            [XPath("//div/a", NodeReturnType = ReturnType.InnerHtml)]
            public string? StringValue { get; set; }
        }


        [Theory]
        [InlineData(typeof(Model_ReturnTypeOuterHTMLOnElementWithStringProperty))]
        [InlineData(typeof(Model_ReturnTypeOuterHTMLAsNamedArgOnElementWithStringProperty))]
        public void ReturnTypeOuterHTMLOnElementWithStringProperty(Type modelType)
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var model = (IModelWithStringProperty) doc.DocumentNode.GetEncapsulatedData(modelType);

            Assert.NotNull(model);
            Assert.Equal("<a href='link1.html'><h1>Link 1</h1></a>", model.StringValue);
        }

        [HasXPath]
        class Model_ReturnTypeOuterHTMLOnElementWithStringProperty : IModelWithStringProperty
        {
            [XPath("//div/a", ReturnType.OuterHtml)]
            public string? StringValue { get; set; }
        }

        [HasXPath]
        class Model_ReturnTypeOuterHTMLAsNamedArgOnElementWithStringProperty : IModelWithStringProperty
        {
            [XPath("//div/a", NodeReturnType = ReturnType.OuterHtml)]
            public string? StringValue { get; set; }
        }


        [Fact]
        public void ImplicitReturnTypeOnAttributeWithStringProperty()
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var model = doc.DocumentNode.GetEncapsulatedData<Model_ImplicitReturnTypeOnAttributeWithStringProperty>();

            Assert.NotNull(model);
            Assert.Equal("link1.html", model.Value);
        }

        [HasXPath]
        class Model_ImplicitReturnTypeOnAttributeWithStringProperty
        {
            [XPath("//div/a", "href")]
            public string? Value { get; set; }
        }


        [Theory]
        [InlineData(typeof(Model_ExplicitReturnTypeOnAttributeWithStringProperty))]
        [InlineData(typeof(Model_ExplicitInvalidReturnTypeOnAttributeWithStringProperty))]
        public void ExplicitReturnTypeOnAttributeWithStringProperty(Type modelType)
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var ex = Assert.Throws<InvalidNodeReturnTypeException>(
                () => doc.DocumentNode.GetEncapsulatedData(modelType)
            );

            Assert.Equal("Specifying a ReturnType value not allowed for XPathAttribute annotations targeting element attributes", ex.Message);
        }

        [HasXPath]
        class Model_ExplicitReturnTypeOnAttributeWithStringProperty
        {
            [XPath("//div/a", "href", NodeReturnType = ReturnType.InnerText)]
            public string? StringValue { get; set; }
        }

        [HasXPath]
        class Model_ExplicitInvalidReturnTypeOnAttributeWithStringProperty
        {
            [XPath("//div/a", "href", NodeReturnType = (ReturnType)567)]
            public string? StringValue { get; set; }
        }


        [Fact]
        public void ImplicitReturnTypeOnElementSequenceWithStringListProperty()
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                    <a href='link2.html'><h1>Link 2</h1></a>
                    <a href='link3.html'><h1>Link 3</h1></a>
                </div>";


            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var model = doc.DocumentNode.GetEncapsulatedData<Model_ImplicitReturnTypeOnElementSequenceWithStringListProperty>();

            Assert.NotNull(model);

            string[] expected = new[] { "Link 1", "Link 2", "Link 3" };
            Assert.Equal(expected, model.StringListValue);
        }

        [HasXPath]
        class Model_ImplicitReturnTypeOnElementSequenceWithStringListProperty
        {
            [XPath("//div/a")]
            public List<string>? StringListValue { get; set; }
        }


        [Theory]
        [InlineData(typeof(Model_ReturnTypeInnerTextOnElementSequenceWithStringListProperty))]
        [InlineData(typeof(Model_ReturnTypeInnerTextAsNamedArgOnElementSequenceWithStringListProperty))]
        public void ReturnTypeInnerTextOnElementSequenceWithStringListProperty(Type modelType)
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                    <a href='link2.html'><h1>Link 2</h1></a>
                    <a href='link3.html'><h1>Link 3</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var model = (IModelWithStringListProperty) doc.DocumentNode.GetEncapsulatedData(modelType);

            Assert.NotNull(model);

            string[] expected = new[] { "Link 1", "Link 2", "Link 3" };
            Assert.Equal(expected, model.StringListValue);
        }

        [HasXPath]
        class Model_ReturnTypeInnerTextOnElementSequenceWithStringListProperty : IModelWithStringListProperty
        {
            [XPath("//div/a", ReturnType.InnerText)]
            public List<string>? StringListValue { get; set; }
        }

        [HasXPath]
        class Model_ReturnTypeInnerTextAsNamedArgOnElementSequenceWithStringListProperty : IModelWithStringListProperty
        {
            [XPath("//div/a", NodeReturnType = ReturnType.InnerText)]
            public List<string>? StringListValue { get; set; }
        }


        [Theory]
        [InlineData(typeof(Model_ReturnTypeInnerHTMLOnElementSequenceWithStringListProperty))]
        [InlineData(typeof(Model_ReturnTypeInnerHTMLAsNamedArgOnElementSequenceWithStringListProperty))]
        public void ReturnTypeInnerHTMLOnElementSequenceWithStringListProperty(Type modelType)
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                    <a href='link2.html'><h1>Link 2</h1></a>
                    <a href='link3.html'><h1>Link 3</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var model = (IModelWithStringListProperty) doc.DocumentNode.GetEncapsulatedData(modelType);

            Assert.NotNull(model);

            string[] expected = new[]
            {
                "<h1>Link 1</h1>",
                "<h1>Link 2</h1>",
                "<h1>Link 3</h1>"
            };
            Assert.Equal(expected, model.StringListValue);
        }

        [HasXPath]
        class Model_ReturnTypeInnerHTMLOnElementSequenceWithStringListProperty : IModelWithStringListProperty
        {
            [XPath("//div/a", ReturnType.InnerHtml)]
            public List<string>? StringListValue { get; set; }
        }

        [HasXPath]
        class Model_ReturnTypeInnerHTMLAsNamedArgOnElementSequenceWithStringListProperty : IModelWithStringListProperty
        {
            [XPath("//div/a", NodeReturnType = ReturnType.InnerHtml)]
            public List<string>? StringListValue { get; set; }
        }


        [Theory]
        [InlineData(typeof(Model_ReturnTypeOuterHTMLOnElementSequenceWithStringListProperty))]
        [InlineData(typeof(Model_ReturnTypeOuterHTMLAsNamedArgOnElementSequenceWithStringListProperty))]
        public void ReturnTypeOuterHTMLOnElementSequenceWithStringListProperty(Type modelType)
        {
            const string html =
                @"<div>
                    <a href='link1.html'><h1>Link 1</h1></a>
                    <a href='link2.html'><h1>Link 2</h1></a>
                    <a href='link3.html'><h1>Link 3</h1></a>
                </div>";

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var model = (IModelWithStringListProperty) doc.DocumentNode.GetEncapsulatedData(modelType);

            Assert.NotNull(model);

            string[] expected = new[]
            {
                "<a href='link1.html'><h1>Link 1</h1></a>",
                "<a href='link2.html'><h1>Link 2</h1></a>",
                "<a href='link3.html'><h1>Link 3</h1></a>"
            };
            Assert.Equal(expected, model.StringListValue);
        }

        [HasXPath]
        class Model_ReturnTypeOuterHTMLOnElementSequenceWithStringListProperty : IModelWithStringListProperty
        {
            [XPath("//div/a", ReturnType.OuterHtml)]
            public List<string>? StringListValue { get; set; }
        }

        [HasXPath]
        class Model_ReturnTypeOuterHTMLAsNamedArgOnElementSequenceWithStringListProperty : IModelWithStringListProperty
        {
            [XPath("//div/a", NodeReturnType = ReturnType.OuterHtml)]
            public List<string>? StringListValue { get; set; }
        }



        interface IModelWithStringProperty
        {
            string? StringValue { get; set; }
        }

        interface IModelWithStringListProperty
        {
            List<string>? StringListValue { get; set; }
        }
    }
}
