# AppendChildren

## public void AppendChildren(HtmlNodeCollection newChildren)

Adds the specified node to the end of the list of children of this node. AppendChildren method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

newChildren: The node list to add. May not be null.

### Example

The following example append children nodes. 

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode h2Node = HtmlNode.CreateNode("<h2> This is h2 heading</h2>");
HtmlNode pNode1 = HtmlNode.CreateNode("<p> This is appended paragraph 1</p>");
HtmlNode pNode2 = HtmlNode.CreateNode("<p> This is appended paragraph 2</p>");

HtmlNodeCollection children = new HtmlNodeCollection(htmlBody);

children.Add(h2Node);
children.Add(pNode1);
children.Add(pNode2);

htmlBody.AppendChildren(children);

```

Click [here](https://dotnetfiddle.net/zSLsQB) to run this example.
