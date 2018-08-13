# Elements

## public IEnumerable < HtmlNode > Elements(string name)

Gets first generation child nodes with matching names. Elements method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

name: The name of the child node.

### Returns:

Returns a collection of first generation child nodes with matching names.

### Example

The following example displays the first-generation child nodes with matching names.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

var nodes = htmlBody.Elements("h2");
		
foreach (var node in nodes)
{
    if (node.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(node.OuterHtml);
    }
}

```

Click [here](https://dotnetfiddle.net/eN5vpD) to run this example.
