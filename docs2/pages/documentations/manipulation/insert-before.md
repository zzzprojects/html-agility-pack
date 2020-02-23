# InsertBefore

## public HtmlNode InsertBefore(HtmlNode newChild, HtmlNode refChild)

Inserts the specified node immediately before the specified reference node. InsertBefore method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

newChild: The node to insert. May not be null.

refChild: The node that is the reference node. The newChild is placed before this node.

### Returns:

The node being inserted.

### Example

The following example creates an HTML node and insert before first child. 

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode refChild = htmlBody.ChildNodes[1];
            
HtmlNode newChild = HtmlNode.CreateNode("<h1> This is inserted before node heading</h>");
		
htmlBody.InsertBefore(newChild, refChild);

```

Click [here](https://dotnetfiddle.net/bgeDoP) to run this example.
