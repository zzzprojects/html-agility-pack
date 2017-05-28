---
layout: default
title: Clone
permalink: clone
---

{% include template-h1.html %}

## public HtmlNode Clone()

Creates a duplicate of the node. Clone method is a member of **HtmlAgilityPack.HtmlNode**

### Returns:

The duplicate of the node.

### Example

The following example creates a buplicate of the node. 

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode newHtmlBody = htmlBody.Clone();

{% endhighlight %}

Click [here](https://dotnetfiddle.net/E5Ohlu) to run this example.
