---
layout: default
title: RemoveChild
permalink: remove-child
---

{% include template-h1.html %}

## RemoveChild(HtmlNode oldChild) 

Removes the specified child node.

### Parameters:

oldChild: The node being removed. May not be null.

### Returns:

The node removed.

### Examples

The following example remove the first child Node.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();

htmlDoc.LoadHtml(html);

var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//body");

foreach (var node in htmlNodes)
{
    HtmlNodeCollection childNodes = node.ChildNodes;

    node.RemoveChild(childNodes[0]);
}

{% endhighlight %}

## RemoveChild(HtmlNode oldChild, bool keepGrandChildren) 

Removes the specified child node.

### Parameters:

oldChild: The node being removed. May not be null.

keepGrandChildren: true to keep grand children ofthe node, false otherwise.

### Returns:

The node removed.

### Examples

The following example remove the first child Node and also its grandchildren nodes.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();

htmlDoc.LoadHtml(html);

var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//body");

foreach (var node in htmlNodes)
{
    HtmlNodeCollection childNodes = node.ChildNodes;

    node.RemoveChild(childNodes[0], false);
}

{% endhighlight %}
