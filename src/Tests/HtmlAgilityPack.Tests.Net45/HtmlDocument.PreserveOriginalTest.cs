using NUnit.Framework;
using System;
using System.IO;
using System.Xml.XPath;

namespace HtmlAgilityPack.Tests.fx._4._5
{
    [TestFixture]
    public class HtmlDocumentPreserveOriginalTest
    {
        private string _contentDirectory;



        [OneTimeSetUp]
        public void Setup()
        {


            _contentDirectory = Path.GetDirectoryName(typeof(HtmlDocumentTests).Assembly.Location).ToString() + "\\files\\";
            //   _contentDirectory = Path.Combine(@"C:\Users\Jonathan\Desktop\Z\zzzproject\HtmlAgilityPack\HtmlAgilityPack.Tests\bin\Debug\files\");
        }

        [Test]
        public void PreserveEmptyAttributesTest()
        {
            var d = new HtmlDocument();
            d.OptionEmptyCollection = true;

            d.GlobalAttributeValueQuote = AttributeValueQuote.Initial;

            d.OptionDefaultUseOriginalName = true;
            //d.OptionPreserveEmptyAttributes = true;

            var html = @"
<form #editForm='ngForm' (ngSubmit)='OnSaveData()' name='globalForm' [dataSourceContext]='detailDataSourceContext'>
  <page editable (beginEdit)='OnBeginEdit()' (cancelEdit)='OnCancelEdit($event)'>

  <page-header pageHeaderIcon='_Lea_ mdi mdi-code-json'>

    <page-header-actions>
      <list-counter formErrorsCounter></list-counter>

      <button mat-button *hasEveryPermission='permissionConstants.LeaProdutos.edit' enterEditButton>
      </button>

      <button mat-button *hasEveryPermission='permissionConstants.LeaProdutos.edit' cancelEditButton>
      </button>

      <button mat-button *hasEveryPermission='permissionConstants.LeaProdutos.edit' type='submit' confirmEditButton>
      </button>

      <refresh-button></refresh-button>
    </page-header-actions>

  </page-header>

    <page-body>
    </page-body>

  </page>
</form>
";
            d.LoadHtml(html);

            var outer = d.DocumentNode.OuterHtml;

            var xpath = XPathExpression.Compile("/form/page/page-header/page-header-actions/button[@enterEditButton]");
            var nodes = d.DocumentNode.SelectNodes(xpath);

            Assert.AreEqual(nodes?.Count, 1, "xpath expression should return 1 node");
            Assert.AreEqual(d.DocumentNode.OuterHtml, html);
        }

        [Test]
        public void PreserveOriginalCasingTest()
        {
            var d = new HtmlDocument();
            d.OptionEmptyCollection = true;

            d.GlobalAttributeValueQuote = AttributeValueQuote.Initial;

            d.OptionDefaultUseOriginalName = true;
            //d.OptionPreserveEmptyAttributes = true;

            var html = @"
<form #editForm='ngForm' (ngSubmit)='OnSaveData()' name='globalForm' [dataSourceContext]='detailDataSourceContext'>
  <page editable (beginEdit)='OnBeginEdit()' (cancelEdit)='OnCancelEdit($event)'>

  <page-Header pageHeaderIcon='_Lea_ mdi mdi-code-json'>

    <page-Header-Actions>
      <list-counter formErrorsCounter></list-counter>

      <button mat-button *hasEveryPermission='permissionConstants.LeaProdutos.edit' enterEditButton>
      </button>

      <button mat-button *hasEveryPermission='permissionConstants.LeaProdutos.edit' cancelEditButton>
      </button>

      <button mat-button *hasEveryPermission='permissionConstants.LeaProdutos.edit' type='submit' confirmEditButton>
      </button>

      <refresh-button></refresh-button>
    </page-Header-Actions>

  </page-Header>

    <page-body>
    </page-body>

  </page>
</form>
";
            d.LoadHtml(html);

            var xpath = XPathExpression.Compile("/form/page/page-Header/page-Header-Actions/button[@enterEditButton]");
            var nodes = d.DocumentNode.SelectNodes(xpath);

            Assert.AreEqual(nodes?.Count, 1, "xpath expression should return 1 node");
            Assert.AreEqual(d.DocumentNode.OuterHtml, html);
        }


        [Test]
        public void PreserveOriginalQuoteTest()
        {
            var d = new HtmlDocument();
            d.OptionEmptyCollection = true;

            d.GlobalAttributeValueQuote = AttributeValueQuote.Initial;
            d.OptionDefaultUseOriginalName = true;

            var filePath = Path.Combine(_contentDirectory, "attr_quote.html");
            var filePathExpected = Path.Combine(_contentDirectory, "attr_quote_expected.html");
            d.Load(filePath);

            var xpath = XPathExpression.Compile("/form/page/page-body/card/data-group/mat-form-field[@*[local-name() = 'xdt:Transform' and . = \"InsertAfter(mat-form-field[mat-select/@name = 'tipoProdutoId'])\"]]/mat-select/mat-option");
            var nodes = d.DocumentNode.SelectNodes(xpath);

            Assert.AreEqual(nodes?.Count, 1, "xpath expression should return 1 node");
            Assert.AreEqual(File.ReadAllText(filePathExpected), d.DocumentNode.OuterHtml);

            var clone = nodes[0].CloneNode(true);

            var expectedOuterNode = @"<mat-option *ngFor=""let dimension of lea546CATBEM$  | async | filterDimensionByValue:( simulationRequest.tipoProdutoId |  commonData:lea508SUBPROD$:'id':'code')"" [value]=""dimension.dimensionId"">


                                {{ dimension.code }} - {{ dimension.description }}
                            </mat-option>";

            Assert.AreEqual(expectedOuterNode, clone.OuterHtml);

        }


        [Test]
        public void PreserveClonedEmptyAttributesTest()
        {
            var d = new HtmlDocument();
            d.GlobalAttributeValueQuote = AttributeValueQuote.Initial;
            d.OptionDefaultUseOriginalName = true;

            var html = @"<list-counter formErrorsCounter></list-counter>";
            d.LoadHtml(html);

            var cloned = d.DocumentNode.CloneNode(true);

            Assert.AreEqual(@"<list-counter formErrorsCounter></list-counter>", cloned.OuterHtml);
        }
    }
}