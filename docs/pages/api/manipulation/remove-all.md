---
layout: default
title: RemoveAll
permalink: remove-all
---

{% include template-h1.html %}

## public void RemoveAll() 

Removes all the children and/or attributes of the current node. RemoveAll method is a member of **HtmlAgilityPack.HtmlNode**

### Examples

The following example removes the first child node from the parent collection, as well as all its children and attributes.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();

htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

HtmlNode node = htmlBody.ChildNodes[1];

node.RemoveAll();

{% endhighlight %}

Click [here](https://dotnetfiddle.net/LFexCy) to run this example.
