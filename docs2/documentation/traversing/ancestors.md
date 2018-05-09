# Ancestors

## public IEnumerable < HtmlNode > Ancestors()

Gets all the ancestors of the node. Ancestors method is a member of **HtmlAgilityPack.HtmlNode**

### Returns:

Returns a collection of all ancestor nodes of this element.

### Example

The following example displays the name of all the ancestors.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//b");

foreach (var nNode in node.Ancestors())
{
    if (nNode.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(nNode.Name);
    }
}

```

Click [here](https://dotnetfiddle.net/Kth8sh) to run this example.

## public IEnumerable < HtmlNode > Ancestors(string name)

Gets ancestors with matching name. Ancestors method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

name: The name of the ancestor node.

### Returns:

Returns a collection of all ancestor nodes of this element with matching name.

### Example

The following example displays the name of the ancestors with matching name.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//b");

foreach (var nNode in node.Ancestors("body"))
{
    if (nNode.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine("Node name: " + nNode.Name);
        Console.WriteLine(nNode.InnerText);
    } 
}

```

Click [here](https://dotnetfiddle.net/ZBt7TO) to run this example.
