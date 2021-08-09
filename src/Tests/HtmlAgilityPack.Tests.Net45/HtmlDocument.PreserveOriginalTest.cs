using System;
using System.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlAgilityPack.Tests.fx._4._5
{
    [TestClass]
    public class HtmlDocumentPreserveOriginalTest
    {
        [TestMethod]
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

        [TestMethod]
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
    }
}