# OuterHtml

## public virtual string OuterHtml { get; }

Gets the object and its content in HTML. OuterHtml is a member of **HtmlAgilityPack.HtmlNode**

### Example

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//body/h1");

foreach (var node in htmlNodes)
{
    Console.WriteLine(node.OuterHtml);
}

```

Click [here](https://dotnetfiddle.net/By222n) to run this example.
