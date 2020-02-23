# From File

## Load Html From File

HtmlDocument.Load method loads an HTML document from a file.

### Example

The following example loads Html from file.

```csharp {:gist="118d4dd3f8fbf12926947603da392fb4"}

var path = @"test.html";
		
var doc = new HtmlDocument();
doc.Load(path);

var node = doc.DocumentNode.SelectSingleNode("//body");

Console.WriteLine(node.OuterHtml);	

```

Click [here](https://dotnetfiddle.net/EsvZyg) to run this example.
