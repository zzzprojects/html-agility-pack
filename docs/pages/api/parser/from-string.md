---
layout: default
title: From String
permalink: from-string
---

{% include template-h1.html %}

## Load Html From String

HtmlDocument.LoadHtml method loads the HTML document from the specified string.

### Example

The following example loads an Html from the specified string.

{% highlight csharp %}

var html = @"<!DOCTYPE html>
<html>
<body>
	<h1>This is <b>bold</b> heading</h1>
	<p>This is <u>underlined</u> paragraph</p>
	<h2>This is <i>italic</i> heading</h2>
</body>
</html> ";

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");

Console.WriteLine(htmlBody.OuterHtml);	

{% endhighlight %}

Click [here](https://dotnetfiddle.net/fKeTAp) to run this example.
