---
layout: default
title: HTML Attributes
permalink: attributes
---

{% include template-h1.html %}

Traversing allow you to traverse through HTML node.

## Methods

| Name | Description |
| :--- | :---------- |
| Add(HtmlAttribute) | Adds supplied item to collection |
| Add(String, String) | Adds a new attribute to the collection with the given values |
| Append(String) | Creates and inserts a new attribute as the last attribute in the collection. |
| Append(HtmlAttribute) | Inserts the specified attribute as the last attribute in the collection. |
| Append(String, string) | Creates and inserts a new attribute as the last attribute in the collection. |
| Remove() | Removes all attributes from the collection |
| Remove(String) | Removes an attribute from the list, using its name. If there are more than one attributes with this name, they will all be removed. |
| Remove(HtmlAttribute) | Removes a given attribute from the list. |
| RemoveAll(HtmlAttribute) | Remove all attributes in the list. |
| RemoveAt() | Removes the attribute at the specified index. |
| SetAttributeValue() | Helper method to set the value of an attribute of this node. If the attribute is not found, it will be created automatically. |
