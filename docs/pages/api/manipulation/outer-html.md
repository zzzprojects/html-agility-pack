---
layout: default
title: OuterHtml
permalink: outer-html
---

{% include template-h1.html %}

## public virtual string OuterHtml { get; }

Gets the object and its content in HTML. OuterHtml is a member of **HtmlAgilityPack.HtmlNode**

### Example

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//body/h1");

foreach (var node in htmlNodes)
{
    Console.WriteLine(node.OuterHtml);
}

{% endhighlight %}

Click [here](https://dotnetfiddle.net/By222n) to run this example.
