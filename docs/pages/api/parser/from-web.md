---
layout: default
title: From Web
permalink: from-web
---

{% include template-h1.html %}

## Load Html From Web

HtmlWeb.Load method gets an HTML document from an internet resource.

### Example

The following example loads an Html from the web.

{% highlight csharp %}

var html = @"http://html-agility-pack.net/";

HtmlWeb web = new HtmlWeb();

var htmlDoc = web.Load(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);

{% endhighlight %}

Click [here](https://dotnetfiddle.net/Vtwi7g) to run this example.
