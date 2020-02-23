# SetAttributeValue

## public HtmlAttribute SetAttributeValue(string name, string value)

Helper method to set the value of an attribute of this node. If the attribute is not found, it will be created automatically. SetAttributeValue method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

name: The name of the attribute to set. May not be null.
value: The value for the attribute.

### Example

The following example sets an attribute value.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");
		
h1Node.Attributes.Append("style");
		
h1Node.SetAttributeValue("style", "color:blue");

```

Click [here](https://dotnetfiddle.net/WwLgeW) to run this example.
