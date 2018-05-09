# DescendantNodesAndSelf

## public IEnumerable < HtmlNode > DescendantNodesAndSelf([int level = 0])

Gets a collection of all descendant nodes of this element, in document order. DescendantNodesAndSelf method is a member of **HtmlAgilityPack.HtmlNode**

### Returns:

Returns a collection of all descendant nodes of this element, in document order.

### Example

The following example displays the name of all the descendant nodes and the node itself.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

foreach (var nNode in node.DescendantNodesAndSelf())
{
    if (nNode.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(nNode.Name);
    }
}

```

Click [here](https://dotnetfiddle.net/OMpg6Z) to run this example.
