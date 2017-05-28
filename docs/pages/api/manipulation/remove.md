---
layout: default
title: Remove
permalink: remove
---

{% include template-h1.html %}

## public void Remove() 

Removes node from parent collection. Remove method is a member of **HtmlAgilityPack.HtmlNode**

### Examples

The following example removes the first child node from the parent collection, but that node will still exist.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();

htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

HtmlNode node = htmlBody.ChildNodes[1];

node.Remove();

{% endhighlight %}

Click [here](https://dotnetfiddle.net/EENTHk) to run this example.
