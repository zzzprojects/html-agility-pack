# Descendants

## public IEnumerable < HtmlNode > Descendants([int level = 0])

Gets all descendant nodes in enumerated list. Descendants method is a member of **HtmlAgilityPack.HtmlNode**

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

foreach (var nNode in node.Descendants())
{
    if (nNode.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(nNode.Name);
    }
}

```

Click [here](https://dotnetfiddle.net/gygZsT) to run this example.

## public IEnumerable < HtmlNode > Descendants(string name)

Get all descendant nodes with matching name. Descendants method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

name: The name of the descendant node.

### Returns:

Returns a collection of all descendant nodes with matching name.

### Example

The following example displays the name of all the descendant nodes with matching name.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

foreach (var nNode in node.Descendants("h2"))
{
    if (nNode.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(nNode.Name);
    }
}

```

Click [here](https://dotnetfiddle.net/1HYt4Q) to run this example.
