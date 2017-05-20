---
layout: default
title: HTML SelectSingleNode
permalink: select-single-node
---

{% include template-h1.html %}

## SelectSingleNode Method

Selects first HtmlNode matching the HtmlAgilityPack.HtmlNode.XPath expression.

### Parameters:

xpath: The XPath expression. May not be null.

### Returns:

The first HtmlAgilityPack.HtmlNode that matches the XPath query or a null reference if no matching node was found.

### Examples

The following example selects the first node matching the XPath expression using SelectNodes method.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

string name = htmlDoc.DocumentNode
    .SelectSingleNode("//td/input")
    .Attributes["value"].Value;

{% endhighlight %}

Click [here](https://dotnetfiddle.net/KHzARJ) to run this example.

