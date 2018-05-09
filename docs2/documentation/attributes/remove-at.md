# RemoveAt

## public void RemoveAt(int index)

Removes the attribute at the specified index. RemoveAt method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

index: The index of the attribute to remove.

### Example

The following example removes an attribute from the list at the specified index.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");
		
h1Node.Attributes.RemoveAt(1);

```

Click [here](https://dotnetfiddle.net/nlbCIQ) to run this example.
