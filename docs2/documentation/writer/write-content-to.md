# WriteContentTo

## public void WriteContentTo()

Saves all the children of the node to a string. WriteContentTo method is a member of **HtmlAgilityPack.HtmlNode**

### Returns:

The saved string.

### Example

The following example saves all the children of the node to a string.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
string result = node.WriteContentTo();

```

Click [here](https://dotnetfiddle.net/mLxVJz) to run this example.

## public void WriteContentTo(TextWriter outText, [int level = 0])

Saves all the children of the node to the specified TextWriter. WriteContentTo method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

outText: The TextWriter to which you want to save.
level: Identifies the level we are in starting at root with 0

### Example

The following example saves all the children of the node to a string.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

TextWriter writer = File.CreateText("TextWriter.html");
		
var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

node.WriteContentTo(writer);

```

Click [here](https://dotnetfiddle.net/SscjAW) to run this example.
