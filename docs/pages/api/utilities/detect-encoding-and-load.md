---
layout: default
title: DetectEncodingAndLoad
permalink: detect-encoding-and-load
---

{% include template-h1.html %}

## public void DetectEncodingAndLoad(string path)

Detects the encoding of an HTML document from a file first, and then loads the file. DetectEncodingAndLoad method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

path: The complete file path to be read.

### Example

The following example detects the encoding of an HTML file first, and then loads it.

{% highlight csharp %}

var htmlNewDoc = new HtmlDocument();

htmlNewDoc.DetectEncodingAndLoad("Test.html");

{% endhighlight %}

Click [here](https://dotnetfiddle.net/9pO7lN) to run this example.

## public void DetectEncodingAndLoad(string path, bool detectEncoding)

Detects the encoding of an HTML document from a file first, and then loads the file. DetectEncodingAndLoad method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

path: The complete file path to be read. May not be null.
detectEncoding: true to detect encoding, false otherwise.

### Example

The following example detects the encoding of an HTML file first, and then loads it.
https://dotnetfiddle.net/LqhqAq
{% highlight csharp %}

var htmlNewDoc = new HtmlDocument();

htmlNewDoc.DetectEncodingAndLoad("Test.html", true);

{% endhighlight %}

Click [here](https://dotnetfiddle.net/LqhqAq) to run this example.
