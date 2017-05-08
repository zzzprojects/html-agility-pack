---
layout: default
title: HTML Manipulation
permalink: manipulation
---

{% include template-h1.html %}

Traversing allow you to traverse through HTML node.

## Properties

| Name | Description |
| :--- | :---------- |
| InnerHtml | Gets or Sets the HTML between the start and end tags of the object. |
| InnerText | Gets or Sets the text between the start and end tags of the object. | 
| OuterHtml | Gets or Sets the object and its content in HTML. |
| ParentNode | Gets the parent of this node (for nodes that can have parents). |


## Methods

| Name | Description |
| :--- | :---------- |
| AppendChild() | Adds the specified node to the end of the list of children of this node. |
| AppendChildren() | Adds the specified node to the end of the list of children of this node. |
| Clone() | Creates a duplicate of the node |
| CloneNode(Boolean) | Creates a duplicate of the node. |
| CloneNode(String) | Creates a duplicate of the node and changes its name at the same time. |
| CloneNode(String, Boolean) | Creates a duplicate of the node and changes its name at the same time. |
| CopyFrom(HtmlNode) | Creates a duplicate of the node and the subtree under it. |
| CopyFrom(HtmlNode, Boolean) | Creates a duplicate of the node. |
| CreateNode() | Creates an HTML node from a string representing literal HTML. |
| InsertAfter() | Inserts the specified node immediately after the specified reference node. |
| InsertBefore | Inserts the specified node immediately before the specified reference node. |
| PrependChild | Adds the specified node to the beginning of the list of children of this node. |
| PrependChildren | Adds the specified node list to the beginning of the list of children of this node. |
| Remove | Removes node from parent collection |
| RemoveAll | Removes all the children and/or attributes of the current node. |
| RemoveAllChildren | Removes all the children of the current node. |
| RemoveChild(HtmlNode) | Removes the specified child node. |
| RemoveChild(HtmlNode, Boolean) | Removes the specified child node. |
| ReplaceChild() | Replaces the child node oldChild with newChild node. |
| RemoveChild(HtmlNode, Boolean) | Removes the specified child node.  |
| RemoveChild(HtmlNode, Boolean) | Removes the specified child node.  |
