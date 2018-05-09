# WriteTo

## public string WriteTo()

Saves the current node to a string. WriteTo method is a member of **HtmlAgilityPack.HtmlNode**

### Returns:

The saved string.

### Example

The following example saves the current node to a string.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
string result = node.WriteTo();

```

Click [here](https://dotnetfiddle.net/57tPH2) to run this example.

## public void WriteTo(TextWriter outText, [int level = 0])

Saves the current node to the specified TextWriter. WriteTo method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

outText: The TextWriter to which you want to save.
level: identifies the level we are in starting at root with 0

### Example

The following example saves the current node to the specified TextWriter.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

TextWriter writer = File.CreateText("TextWriter.html");
        
var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

node.WriteTo(writer);

```

Click [here](https://dotnetfiddle.net/q7WBJ0) to run this example.

## public void WriteTo(XmlWriter writer)

Saves the current node to the specified XmlWriter. WriteTo method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

writer: The XmlWriter to which you want to save.

### Example

The following example saves the current node to the specified XmlWriter.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

StringWriter sw = new StringWriter();

XmlTextWriter xw = new XmlTextWriter(sw);

node.WriteTo(xw);

```

Click [here](https://dotnetfiddle.net/zgaXfg) to run this example.
