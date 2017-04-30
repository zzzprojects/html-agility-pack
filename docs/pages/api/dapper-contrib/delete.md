---
layout: default
title: Dapper Contrib - Delete
permalink: delete
---

{% include template-h1.html %}

## Description
DELETE a single or many entities.

- [Delete Single](#example---delete-single)
- [Delete Many](#example---delete-single)

## Example - Delete Single
DELETE a single entitiy.

{% highlight csharp %}
using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var isSuccess = connection.Delete(new Invoice {InvoiceID = 1});
}
{% endhighlight %}

## Example - Delete Many
DELETE many entities.

{% highlight csharp %}
using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var list = new List<Invoice>()
    {
        new Invoice {InvoiceID = 1},
        new Invoice {InvoiceID = 2},
        new Invoice {InvoiceID = 3}
    };

    var isSuccess = connection.Delete(list);
}
{% endhighlight %}
