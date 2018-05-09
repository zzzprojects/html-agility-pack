# First Child

## public HtmlNode FirstChild { get; }

Gets the first child of the node. FirstChild is a member of **HtmlAgilityPack.HtmlNode**

### Example

The following example displays the first child of the node.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//body");

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode firstChild = htmlBody.FirstChild;
		
Console.WriteLine(firstChild.OuterHtml);	

```

Click [here](https://dotnetfiddle.net/DJeEwt) to run this example.
