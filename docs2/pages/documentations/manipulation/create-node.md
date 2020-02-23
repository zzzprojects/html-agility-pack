# CreateNode

## public static HtmlNode CreateNode(string html)

Creates an HTML node from a string representing literal HTML. CreateNode method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

html: The HTML text.

### Returns:

The newly created node instance.

### Example

The following example creates an HTML node and add as child node. 

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode newPara = HtmlNode.CreateNode("<p>This a new paragraph</p>");

htmlBody.ChildNodes.Add(newPara);

```

Click [here](https://dotnetfiddle.net/0GtVim) to run this example.
