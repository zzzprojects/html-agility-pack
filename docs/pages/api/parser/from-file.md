---
layout: default
title: From File
permalink: from-file
---

{% include template-h1.html %}

## Load Html From File

HtmlDocument.Load method loads an HTML document from a file.

### Example

The following example loads Html from file.

{% highlight csharp %}

var html = @"C:\html\test.html";

var htmlDoc = new HtmlDocument();
htmlDoc.Load(html);

var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);	

{% endhighlight %}
