---
layout: default
title: ChildNodes
permalink: child-nodes
---

{% include template-h1.html %}

## public HtmlNodeCollection ChildNodes { get; }

Gets all the children of the node. ChildNodes is a member of **HtmlAgilityPack.HtmlNode**

### Example

The following example displays all the children element of the node.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNodeCollection childNodes = htmlBody.ChildNodes;
		
foreach (var node in childNodes)
{
    if (node.NodeType == HtmlNodeType.Element)
    {
        Console.WriteLine(node.OuterHtml);
    }
}	

{% endhighlight %}

Click [here](https://dotnetfiddle.net/9drY3o) to run this example.
