# PrependChild

## public HtmlNode PrependChild(HtmlNode newChild)

Adds the specified node to the beginning of the list of children of this node. PrependChild method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

newChild: The node to add. May not be null.

### Returns:

The node added.

### Example

The following example add child node at the beginning. 

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode newChild = HtmlNode.CreateNode("<h1> This is added at the beginning</h>");
		
htmlBody.PrependChild(newChild);

```

Click [here](https://dotnetfiddle.net/pWFZzv) to run this example.
