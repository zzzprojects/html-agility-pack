---
layout: default
title: AppendChild
permalink: append-child
---

{% include template-h1.html %}

## public HtmlNode AppendChild(HtmlNode newChild)

Adds the specified node to the end of the list of children of this node. AppendChild method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

newChild: The node to add. May not be null.

### Returns:

The node added.

### Example

The following example append child node. 

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode h2Node = HtmlNode.CreateNode("<h2> This is h2 heading</h2>");

htmlBody.AppendChild(h2Node);

{% endhighlight %}

Click [here](https://dotnetfiddle.net/ANYiid) to run this example.
