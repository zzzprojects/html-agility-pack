# InnerText

## public virtual string InnerText { get; }

Gets the text between the start and end tags of the object. InnerText is a member of **HtmlAgilityPack.HtmlNode**

### Example

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//body/h1");

foreach (var node in htmlNodes)
{
    Console.WriteLine(node.InnerText);
}

```

Click [here](https://dotnetfiddle.net/2wxxi9) to run this example.
