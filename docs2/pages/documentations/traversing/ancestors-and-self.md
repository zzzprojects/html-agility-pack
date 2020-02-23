# AncestorsAndSelf

## public IEnumerable < HtmlNode > AncestorsAndSelf()

Gets all the ancestors of the node and the node itself. AncestorsAndSelf method is a member of **HtmlAgilityPack.HtmlNode**

### Returns:

Returns a collection of all ancestor nodes and the node itself as well.

### Example

The following example displays the name of the selected node and all of its ancestors.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);
		
var node = htmlDoc.DocumentNode.SelectSingleNode("//u");

 foreach (var nNode in node.AncestorsAndSelf())
 {
     if (nNode.NodeType == HtmlNodeType.Element)
     {
         Console.WriteLine(nNode.Name);
     }
 }		

```

Click [here](https://dotnetfiddle.net/Kth8sh) to run this example.

## public IEnumerable < HtmlNode > AncestorsAndSelf(string name)

Gets ancestors and the node itself with matching name. AncestorsAndSelf method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

name: The name of the ancestor node.

### Returns:

Returns a collection of all ancestor nodes and the node itself with matching name.

### Example

The following example displays the name of the selected node and all of its ancestors with matching name.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//u");

foreach (var nNode in node.AncestorsAndSelf("p"))
{
    if (nNode.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(nNode.Name);
    }
}

```

Click [here](https://dotnetfiddle.net/urjo5m) to run this example.
