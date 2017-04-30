---
layout: default
title: Dapper Contrib - Insert
permalink: insert
---

{% include template-h1.html %}

## Description
INSERT a single or many entities.

- [Insert Single](#example---insert-single)
- [Insert Many](#example---insert-single)

## Example - Insert Single
INSERT a single entitiy.

{% highlight csharp %}
using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var identity = connection.Insert(new InvoiceContrib {Kind = InvoiceKind.WebInvoice, Code = "Insert_Single_1"});
}
{% endhighlight %}

## Example - Insert Many
INSERT many entities.

{% highlight csharp %}
using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var list = new List<InvoiceContrib>
    {
        new InvoiceContrib {Kind = InvoiceKind.WebInvoice, Code = "Insert_Many_1"},
        new InvoiceContrib {Kind = InvoiceKind.WebInvoice, Code = "Insert_Many_2"},
        new InvoiceContrib {Kind = InvoiceKind.StoreInvoice, Code = "Insert_Many_3"}
    };

    var identity = connection.Insert(list);
}
{% endhighlight %}
