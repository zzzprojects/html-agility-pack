---
layout: default
title: CreateNode
permalink: create-node
---

{% include template-h1.html %}

## public static HtmlNode CreateNode(string html)

Creates an HTML node from a string representing literal HTML. CreateNode method is a member of **HtmlAgilityPack.HtmlNode**

### Parameters:

html: The HTML text.

### Returns:

The newly created node instance.

### Example

The following example creates an HTML node and add as child node. 

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
		
HtmlNode newPara = HtmlNode.CreateNode("<p>This a new paragraph</p>");

htmlBody.ChildNodes.Add(newPara);

{% endhighlight %}

Click [here](https://dotnetfiddle.net/0GtVim) to run this example.
