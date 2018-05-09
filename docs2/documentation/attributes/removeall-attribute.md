# Remove

## public void RemoveAll()

Removes all attributes in the list. RemoveAll method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Example

The following example removes all attributes in the list.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");
		
h1Node.Attributes.RemoveAll();

```

Click [here](https://dotnetfiddle.net/t8oy4u) to run this example.
