# Add

## public void Add(HtmlAttribute item)

Adds supplied item to collection. Add method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

item: The attribute item to add.

### Example

The following example adds attribute item.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

Console.WriteLine(h1Node.OuterHtml);
		
var attribute = htmlDoc.CreateAttribute("style", "color: red");
		
h1Node.Attributes.Add(attribute);

```

Click [here](https://dotnetfiddle.net/GwaK1r) to run this example.

## public void Add(string name, string value)

Adds a new attribute to the collection with the given values. Add method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

name: The name of the attribute to add.
value: The value of the attribute to add.

### Example

The following example adds attribute item to the collection with the given values.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

h1Node.Attributes.Add("style", "color: red");

```

Click [here](https://dotnetfiddle.net/Sg6Uz6) to run this example.
