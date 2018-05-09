# DescendantNodes

## public IEnumerable < HtmlNode > DescendantNodes([int level = 0])

Gets all Descendant nodes for this node and each of child nodes. DescendantNodes method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

level: The depth level of the node to parse in the html tree.

### Returns:

Returns a collection of all descendant nodes of this element.

### Example

The following example displays the name of all the descendant nodes.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

foreach (var nNode in node.DescendantNodes())
{
    if (nNode.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(nNode.Name);
    }
}

```

Click [here](https://dotnetfiddle.net/gLl45I) to run this example.
