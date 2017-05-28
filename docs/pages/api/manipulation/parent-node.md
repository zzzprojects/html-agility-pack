---
layout: default
title: ParentNode
permalink: parent-node
---

{% include template-h1.html %}

## public HtmlNode ParentNode { get; }

Gets the parent of this node (for nodes that can have parents). ParentNode is a member of **HtmlAgilityPack.HtmlNode**

### Example

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body/h1");

HtmlNode parentNode = node.ParentNode;

Console.WriteLine(parentNode.Name);

{% endhighlight %}

Click [here](https://dotnetfiddle.net/BHfJdM) to run this example.
