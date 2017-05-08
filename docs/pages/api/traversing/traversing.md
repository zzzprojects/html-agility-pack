---
layout: default
title: HTML Traversing
permalink: traversing
---

{% include template-h1.html %}

Traversing allow you to traverse through HTML node.

## Properties

| Name | Description |
| :--- | :---------- |
| ChildNodes | Gets all the children of the node. |
| FirstChild | Gets the first child of the node. | 
| LastChild | Gets the last child of the node. |
| ParentNode | Gets the parent of this node (for nodes that can have parents). |


## Methods

| Name | Description |
| :--- | :---------- |
| Ancestors() | Gets all the children of the node. |
| Ancestors(String) | Gets the parent of this node (for nodes that can have parents). |
| AncestorsAndSelf() | Returns a collection of all ancestor nodes of this element. |
| AncestorsAndSelf(String) | Gets all anscestor nodes and the current node |
| DescendantNodes | Gets all Descendant nodes for this node and each of child nodes |
| DescendantNodesAndSelf | Returns a collection of all descendant nodes of this element, in document order |
| Descendants() | Gets all Descendant nodes in enumerated list |
| Descendants(String) | Get all descendant nodes with matching name |
| DescendantsAndSelf() | Returns a collection of all descendant nodes of this element, in document order |
| DescendantsAndSelf(String) | Gets all descendant nodes including this node |
| Element | Gets first generation child node matching name |
| Elements | Gets matching first generation child nodes matching name |
