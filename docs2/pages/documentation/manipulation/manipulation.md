# HTML Manipulation

Traversing allow you to traverse through HTML node.

## Properties

| Name | Description |
| :--- | :---------- |
| [InnerHtml](inner-html) | Gets or Sets the HTML between the start and end tags of the object. |
| [InnerText](inner-text) | Gets the text between the start and end tags of the object. | 
| [OuterHtml](outer-html) | Gets the object and its content in HTML. |
| [ParentNode](parent-node) | Gets the parent of this node (for nodes that can have parents). |


## Methods

| Name | Description |
| :--- | :---------- |
| [AppendChild()](append-child) | Adds the specified node to the end of the list of children of this node. |
| [AppendChildren()](append-children) | Adds the specified node to the end of the list of children of this node. |
| [Clone()](clone) | Creates a duplicate of the node |
| [CloneNode(Boolean)](clone-node) | Creates a duplicate of the node. |
| [CloneNode(String)](clone-node#public-htmlnode-clonenodestring-newname) | Creates a duplicate of the node and changes its name at the same time. |
| [CloneNode(String, Boolean)](clone-node#public-htmlnode-clonenodestring-newname-bool-deep) | Creates a duplicate of the node and changes its name at the same time. |
| [CopyFrom(HtmlNode)](copy-from) | Creates a duplicate of the node and the subtree under it. |
| [CopyFrom(HtmlNode, Boolean)](copy-from#public-htmlnode-copyfromhtmlnode-node-bool-deep) | Creates a duplicate of the node. |
| [CreateNode()](create-node) | Creates an HTML node from a string representing literal HTML. |
| [InsertAfter()](insert-after) | Inserts the specified node immediately after the specified reference node. |
| [InsertBefore](insert-before) | Inserts the specified node immediately before the specified reference node. |
| [PrependChild](prepend-child) | Adds the specified node to the beginning of the list of children of this node. |
| [PrependChildren](prepend-children) | Adds the specified node list to the beginning of the list of children of this node. |
| [Remove](remove) | Removes node from parent collection |
| [RemoveAll](remove-all) | Removes all the children and/or attributes of the current node. |
| [RemoveAllChildren](remove-all-children) | Removes all the children of the current node. |
| [RemoveChild(HtmlNode)](remove-child) | Removes the specified child node. |
| [RemoveChild(HtmlNode, Boolean)](remove-child#public-htmlnode-removechildhtmlnode-oldchild-bool-keepgrandchildren) | Removes the specified child node. |
| [ReplaceChild()](replace-child) | Replaces the child node oldChild with newChild node. |
