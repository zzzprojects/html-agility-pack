---
layout: default
title: HTML Writer
permalink: writer
---

{% include template-h1.html %}

Save HtmlDocument && Write HtmlNode

## HtmlDocument - Methods

| Name | Description |
| :--- | :---------- |
| Save(Stream) | Saves the HTML document to the specified stream. |
| Save(StreamWriter) | Saves the HTML document to the specified StreamWriter. |
| Save(TextWriter) | Saves the HTML document to the specified TextWriter. |
| Save(String) | Saves the mixed document to the specified file. |
| Save(XmlWriter) | Saves the HTML document to the specified XmlWriter. |
| Save(Stream, Encoding) | Saves the HTML document to the specified stream. |
| Save(String, Encoding) | Saves the mixed document to the specified file. |

## HtmlNode - Methods

| Name | Description |
| :--- | :---------- |
| WriteContentTo() | Saves all the children of the node to a string. |
| WriteContentTo(TextWriter) | Saves all the children of the node to the specified TextWriter. |
| WriteTo() | Saves the current node to a string. |
| WriteTo(TextWriter) | Saves the current node to the specified TextWriter. |
| WriteTo(XmlWriter) | Saves the current node to the specified XmlWriter. |
