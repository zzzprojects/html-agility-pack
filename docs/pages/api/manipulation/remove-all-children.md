---
layout: default
title: RemoveAllChildren
permalink: remove-all-children
---

{% include template-h1.html %}

## public void RemoveAll() 

Removes all the children of the current node. RemoveAllChildren method is a member of **HtmlAgilityPack.HtmlNode**

### Examples

The following example removes all the children of the current node.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();

htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

htmlBody.RemoveAllChildren();

{% endhighlight %}

Click [here](https://dotnetfiddle.net/aFRmEy) to run this example.
