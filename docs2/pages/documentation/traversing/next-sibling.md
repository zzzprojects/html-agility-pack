# NextSibling

## public HtmlNode NextSibling { get; }

Gets the HTML node immediately following this element. NextSibling is a member of **HtmlAgilityPack.HtmlNode**

### Example

The following example displays the next sibling node.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body/h1");

HtmlNode sibling = node.NextSibling;

while (sibling != null)
{
    if(sibling.NodeType == HtmlNodeType.Element)
        Console.WriteLine(sibling.OuterHtml);

    sibling = sibling.NextSibling;
}

```

Click [here](https://dotnetfiddle.net/k2k3IJ) to run this example.
