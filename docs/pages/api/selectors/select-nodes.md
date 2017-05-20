---
layout: default
title: HTML SelectNodes
permalink: select-nodes
---

{% include template-h1.html %}

## SelectNodes Method

Selects a list of nodes matching the HtmlAgilityPack.HtmlNode.XPath expression.

### Parameters:

xpath: The XPath expression.

### Returns:

An HtmlAgilityPack.HtmlNodeCollection containing a collection of nodes matching the HtmlAgilityPack.HtmlNode.XPath query, or null if no node matched the XPath expression.

### Examples

The following example selects the first node matching the XPath expression using SelectNodes method.

{% highlight csharp %}
var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

string name = htmlDoc.DocumentNode
    .SelectNodes("//td/input")
    .First()
    .Attributes["value"].Value;
{% endhighlight %}

Click [here](https://dotnetfiddle.net/z2y3yl) to run this example.

The following example selects all nodes which are matching the XPath expression.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//td/input");

{% endhighlight %}

Click [here](https://dotnetfiddle.net/ozk9kE) to run this example.
