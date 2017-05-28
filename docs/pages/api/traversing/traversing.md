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
| [ChildNodes](child-nodes) | Gets all the children of the node. |
| [FirstChild](first-child) | Gets the first child of the node. | 
| [LastChild](last-child) | Gets the last child of the node. |
| [ParentNode](parent-node) | Gets the parent of this node (for nodes that can have parents). |


## Methods

| Name | Description |
| :--- | :---------- |
| [Ancestors()](ancestors) | Gets all the ancestor of the node.  |
| [Ancestors(String)](ancestors#public-ienumerable--htmlnode--ancestorsstring-name) | Gets ancestors with matching name. |
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
