# From Browser

## Load Html From Browser

HtmlWeb.Load method gets an HTML document from an web browser. It makes possible to wait for JavaScript to be run by customizing the isBrowserScriptCompleted parameter. 

### Example

The following example loads an Html from the WebBrowser and waits until the text is set for the DIV.

```csharp

string url = "http://html-agility-pack/from-browser";

var web1 = new HtmlWeb();
var doc1 = web1.LoadFromBrowser(url, o =>
{
	var webBrowser = (WebBrowser) o;

	// WAIT until the dynamic text is set
	return !string.IsNullOrEmpty(webBrowser.Document.GetElementById("uiDynamicText").InnerText);
});
var t1 = doc1.DocumentNode.SelectSingleNode("//div[@id='uiDynamicText']").InnerText;

var web2 = new HtmlWeb();
var doc2 = web2.LoadFromBrowser(url, html =>
{
	// WAIT until the dynamic text is set
	return !html.Contains("<div id=\"uiDynamicText\"></div>");
});
var t2 = doc2.DocumentNode.SelectSingleNode("//div[@id='uiDynamicText']").InnerText;

Console.WriteLine("Text 1: " + t1);
Console.WriteLine("Text 2: " + t2);

```

<div id="uiDynamicText"></div>

<script>
setTimeout(function(){ document.getElementById("uiDynamicText").innerHTML = "Dynamic Text for Example"; }, 1000);
</script>
