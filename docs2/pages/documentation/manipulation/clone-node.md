# CloneNode

## public HtmlNode CloneNode(bool deep)

Creates a duplicate of the node. CloneNode method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

deep: true to recursively clone the subtree under the specified node; false to clone only the node itself.

### Returns:

The cloned node.

### Example

The following example clone only the node itself without its children.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode newHtmlBody = htmlBody.CloneNode(false);

```

Click [here](https://dotnetfiddle.net/ETUR7Y) to run this example.

## public HtmlNode CloneNode(string newName)

Creates a duplicate of the node and changes its name at the same time. CloneNode method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

newName: The new name of the cloned node. May not be null.

### Returns:

The cloned node.

### Example

The following example clone the node and changes its name.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode h1Node = htmlBody.ChildNodes[1];

HtmlNode h2Node = h1Node.CloneNode("h2");

```

Click [here](https://dotnetfiddle.net/2bK3FZ) to run this example.

## public HtmlNode CloneNode(string newName, bool deep)

Creates a duplicate of the node and changes its name at the same time. CloneNode method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

newName: The new name of the cloned node. May not be null.

deep: true to recursively clone the subtree under the specified node; false to clone only the node itself.

### Returns:

The cloned node.

### Example

The following example clone only the node itself without its children and changes its name as well.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode h1Node = htmlBody.ChildNodes[1];

HtmlNode h2Node = h1Node.CloneNode("h2");

```

Click [here](https://dotnetfiddle.net/gblMur) to run this example.
