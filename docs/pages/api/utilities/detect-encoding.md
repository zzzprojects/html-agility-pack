---
layout: default
title: DetectEncoding
permalink: detect-encoding
---

{% include template-h1.html %}

## public Encoding DetectEncoding(Stream stream)

Detects the encoding of an HTML stream. DetectEncoding method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

stream: The input stream. May not be null.

### Returns:

The detected encoding.

### Example

The following example detects the encoding of an HTML stream.

{% highlight csharp %}

var htmlNewDoc = new HtmlDocument();

FileStream newfs = new FileStream("Test.html", FileMode.Open);

var encoding = htmlNewDoc.DetectEncoding(newfs);

{% endhighlight %}

Click [here](https://dotnetfiddle.net/ImZV3y) to run this example.

## public Encoding DetectEncoding(TextReader reader)

Detects the encoding of an HTML text provided on a TextReader. DetectEncoding method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

reader: The TextReader used to feed the HTML. May not be null.

### Returns:

The detected encoding.

### Example

The following example detects the encoding of an HTML text provided on a TextReader.

{% highlight csharp %}

var htmlNewDoc = new HtmlDocument();

TextReader tr = File.OpenText("Test.html");

var encoding = htmlNewDoc.DetectEncoding(tr);

{% endhighlight %}

Click [here](https://dotnetfiddle.net/IkDlKt) to run this example.

## public Encoding DetectEncoding(string path)

Detects the encoding of an HTML file. DetectEncoding method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

path: Path for the file containing the HTML document to detect. May not be null.

### Returns:

The detected encoding.

### Example

The following example detects the encoding of an HTML file.

{% highlight csharp %}

var htmlNewDoc = new HtmlDocument();

var encoding = htmlNewDoc.DetectEncoding("Test.html");

{% endhighlight %}

Click [here](https://dotnetfiddle.net/Wa4VTT) to run this example.
