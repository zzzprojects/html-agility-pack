using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace HtmlAgilityPack.Tests
{
	[TestFixture]
	public class HtmlNode
	{
		[Test(Description="Attributes should maintain their original character casing if OptionOutputOriginalCase is true")]
		public void EnsureAttributeOriginalCaseIsPreserved()
		{
			var html = "<html><body><div AttributeIsThis=\"val\"></div></body></html>";
			var doc = new HtmlDocument
				          {
					          OptionOutputOriginalCase = true
				          };
			doc.LoadHtml(html);
			var div = doc.DocumentNode.Descendants("div").FirstOrDefault();
			var writer = new StringWriter();
			div.WriteAttributes(writer, false);
			var result = writer.GetStringBuilder().ToString();
			Assert.AreEqual(" AttributeIsThis=\"val\"", result);
		}
	}
}
