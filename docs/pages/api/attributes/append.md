---
layout: default
title: Append
permalink: append
---

{% include template-h1.html %}

## public HtmlAttribute Append(string name)

Creates and inserts a new attribute as the last attribute in the collection. Append method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

name: The name of the attribute to insert.

### Returns:

The appended attribute.

### Example

The following example append the specified attribute at the end.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

h1Node.Attributes.Append("bgcolor");

{% endhighlight %}

Click [here](https://dotnetfiddle.net/dHQrso) to run this example.

## public HtmlAttribute Append(HtmlAttribute newAttribute)

Inserts the specified attribute as the last attribute in the collection. Append method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

newAttribute: The attribute to insert. May not be null.

### Returns:

The appended attribute.

### Example

The following example append the specified attribute at the end.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");
		
var attribute = htmlDoc.CreateAttribute("align", "left");
		
h1Node.Attributes.Append(attribute);

{% endhighlight %}

Click [here](https://dotnetfiddle.net/1DHAC3) to run this example.

## public HtmlAttribute Append(string name, string value)

Creates and inserts a new attribute as the last attribute in the collection. Append method is a member of **HtmlAgilityPack.HtmlAttributeCollection**

### Parameters:

name: The name of the attribute to insert.
value: The value of the attribute to insert.

### Returns:

The appended attribute.

### Example

The following example creates and inserts a new attribute as the last attribute in the collection.

{% highlight csharp %}

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

var h1Node = htmlDoc.DocumentNode.SelectSingleNode("//h1");

h1Node.Attributes.Append("align", "center");

{% endhighlight %}

Click [here](https://dotnetfiddle.net/TGpHhN) to run this example.
