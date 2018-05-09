# CopyFrom

## public void CopyFrom(HtmlNode node)

Creates a duplicate of the node and the subtree under it. CopyFrom method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

node: The node to duplicate. May not be null.

### Example

The following example duplicate a node and the subtree under it.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode newBody = HtmlNode.CreateNode("<body></body>");
            
newBody.CopyFrom(htmlBody);

```

Click [here](https://dotnetfiddle.net/DxhdH3) to run this example.

## public HtmlNode CopyFrom(HtmlNode node, bool deep)

Creates a duplicate of the node. CopyFrom method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

node: The node to duplicate. May not be null.

deep: true to recursively clone the subtree under the specified node, false to clone only the node itself.

### Returns:

The cloned node.

### Example

The following example clone only the node itself without its children.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode newBody = HtmlNode.CreateNode("<body></body>");
            
newBody.CopyFrom(htmlBody, false);

```

Click [here](https://dotnetfiddle.net/9PBQqs) to run this example.
