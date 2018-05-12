# ReplaceChild

## public HtmlNode ReplaceChild(HtmlNode newChild, HtmlNode oldChild)

Replaces the child node oldChild with newChild node. ReplaceChild method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

newChild: The new node to put in the child list.

oldChild: The node being replaced in the list.

### Returns:

The node replaced.

### Examples

The following example replaces the oldChild node with newChild node.

```csharp

var htmlDoc = new HtmlDocument();

htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

HtmlNode oldChild = htmlBody.ChildNodes[1];
		
HtmlNode newChild = HtmlNode.CreateNode("<h2> This is h2 new child heading</h2>");
		
htmlBody.ReplaceChild(newChild, oldChild);

```

Click [here](https://dotnetfiddle.net/JUfoxv) to run this example.
