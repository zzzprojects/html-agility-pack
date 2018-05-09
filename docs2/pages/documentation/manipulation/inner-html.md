# InnerHtml

## public virtual string InnerHtml { get; set; }

Gets or Sets the HTML between the start and end tags of the object. InnerHtml is a member of **HtmlAgilityPack.HtmlNode**

### Example

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//body/h1");

foreach (var node in htmlNodes)
{
    Console.WriteLine(node.InnerHtml);
}

```

Click [here](https://dotnetfiddle.net/B0JkGV) to run this example.
