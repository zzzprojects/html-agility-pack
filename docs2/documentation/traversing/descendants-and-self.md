# DescendantsAndSelf

## public IEnumerable < HtmlNode > DescendantsAndSelf()

Gets a collection of all descendant nodes of this element, in document order. DescendantsAndSelf method is a member of **HtmlAgilityPack.HtmlNode**

### Returns:

Returns a collection of all descendant nodes of this element, in document order.

### Example

The following example displays the name of all the descendants and the node itself.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

foreach (var nNode in node.DescendantsAndSelf())
{
    if (nNode.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(nNode.Name);
    }
}

```

Click [here](https://dotnetfiddle.net/OMpg6Z) to run this example.

## public IEnumerable < HtmlNode > DescendantsAndSelf(string name)

Get all descendant nodes with matching name and the node itself. Descendants method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

name: The name of the descendant node.

### Returns:

Returns a collection of all descendants with matching name and the node itself.

### Example

The following example displays the name of all the descendant nodes with matching name and the node itself.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

foreach (var nNode in node.DescendantsAndSelf("h2"))
{
    if (nNode.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(nNode.OuterHtml);
    }
}

```

Click [here](https://dotnetfiddle.net/0wwEO5) to run this example.
