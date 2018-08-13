# RemoveChild

## public HtmlNode RemoveChild(HtmlNode oldChild) 

Removes the specified child node. RemoveChild method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

oldChild: The node being removed. May not be null.

### Returns:

The node removed.

### Examples

The following example remove the child node h1.

```csharp

var htmlDoc = new HtmlDocument();

htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

HtmlNode node = htmlBody.ChildNodes[1];

htmlBody.RemoveChild(node);

```

Click [here](https://dotnetfiddle.net/TSNTHW) to run this example.

## public HtmlNode RemoveChild(HtmlNode oldChild, bool keepGrandChildren) 

Removes the specified child node. RemoveChild method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

oldChild: The node being removed. May not be null.

keepGrandChildren: true to keep grandchildren of the node, false otherwise.

### Returns:

The node removed.

### Examples

The following example remove the child node but will keep grandchild node.

```csharp

var htmlDoc = new HtmlDocument();

htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

HtmlNode node = htmlBody.ChildNodes[1];

htmlBody.RemoveChild(node, true);

```

Click [here](https://dotnetfiddle.net/bSWNON) to run this example.
