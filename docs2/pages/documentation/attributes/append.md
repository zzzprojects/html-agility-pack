# Append

## public HtmlAttribute Append(string name)

Creates and inserts a new attribute as the last attribute in the collection. Append method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

name: The name of the attribute to insert.

### Returns:

The appended attribute.

### Example

The following example append the specified attribute at the end.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

h1Node.Attributes.Append("bgcolor");

```

Click [here](https://dotnetfiddle.net/dHQrso) to run this example.

## public HtmlAttribute Append(HtmlAttribute newAttribute)

Inserts the specified attribute as the last attribute in the collection. Append method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

newAttribute: The attribute to insert. May not be null.

### Returns:

The appended attribute.

### Example

The following example append the specified attribute at the end.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");
		
var attribute = htmlDoc.CreateAttribute("align", "left");
		
h1Node.Attributes.Append(attribute);

```

Click [here](https://dotnetfiddle.net/1DHAC3) to run this example.

## public HtmlAttribute Append(string name, string value)

Creates and inserts a new attribute as the last attribute in the collection. Append method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

name: The name of the attribute to insert.
value: The value of the attribute to insert.

### Returns:

The appended attribute.

### Example

The following example creates and inserts a new attribute as the last attribute in the collection.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

h1Node.Attributes.Append("align", "center");

```

Click [here](https://dotnetfiddle.net/TGpHhN) to run this example.
