# LastChild

## public HtmlNode LastChild { get; }

Gets the last child of the node. LastChild is a member of **HtmlAgilityPack.HtmlNode**

### Example

The following example displays the last child of the node.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//body");

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode lastChild = htmlBody.LastChild;
		
Console.WriteLine(lastChild.OuterHtml);	

```

Click [here](https://dotnetfiddle.net/W7K9JO) to run this example.
