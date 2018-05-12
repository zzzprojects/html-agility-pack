# InsertAfter

## public HtmlNode InsertAfter(HtmlNode newChild, HtmlNode refChild)

Inserts the specified node immediately after the specified reference node. InsertAfter method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

newChild: The node to insert. May not be null.

refChild: The node that is the reference node. The newNode is placed after the refNode.

### Returns:

The node being inserted.

### Example

The following example creates an HTML node and insert after first child. 

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode refChild = htmlBody.ChildNodes[1];
            
HtmlNode newChild = HtmlNode.CreateNode("<p> This is inserted after node paragraph</p>");

htmlBody.InsertAfter(newChild, refChild);

```

Click [here](https://dotnetfiddle.net/cWpYzz) to run this example.
