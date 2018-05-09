# PrependChildren

## public void PrependChildren(HtmlNodeCollection newChildren)

Adds the specified node list to the beginning of the list of children of this node. PrependChildren method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

newChildren: The node list to add. May not be null.

### Example

The following example add node list to the beginning of the list of children of this node. 

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

HtmlNode h1Node = HtmlNode.CreateNode("<h1> This is new heading</h1>");

HtmlNode pNode = HtmlNode.CreateNode("<p> This is new paragraph 1</p>");

HtmlNodeCollection newChildren = new HtmlNodeCollection(htmlBody);

newChildren.Add(pNode);

newChildren.Add(h1Node);

htmlBody.PrependChildren(newChildren);

```

Click [here](https://dotnetfiddle.net/dLgqd0) to run this example.
