# Remove

## public void Remove()

Removes all attributes from the collection. Remove method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Example

The following example removes all attributes from the collection.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");
		
h1Node.Attributes.Remove();

```

Click [here](https://dotnetfiddle.net/otZ2Et) to run this example.

## public void Remove(string name)

Removes an attribute from the list, using its name. If there are more than one attributes with this name, they will all be removed. Remove method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

name: The attribute's name. May not be null.

### Example

The following example removes an attribute from the list, using its name.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");
		
h1Node.Attributes.Remove("align");

```

Click [here](https://dotnetfiddle.net/EHO18U) to run this example.

## public void Remove(HtmlAttribute attribute)

Removes a given attribute from the list. Remove method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

attribute: The attribute to remove. May not be null.

### Example

The following example removes a first attribute from the list.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

var attr = h1Node.Attributes.First();

h1Node.Attributes.Remove(attr);

```

Click [here](https://dotnetfiddle.net/d4EVRi) to run this example.
