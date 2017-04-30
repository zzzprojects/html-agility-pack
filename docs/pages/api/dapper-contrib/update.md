---
layout: default
title: Dapper Contrib - Update
permalink: update
---

{% include template-h1.html %}

## Description
UPDATE a single or many entities.

- [Update Single](#example---update-single)
- [Update Many](#example---update-single)

## Example - Update Single
UPDATE a single entitiy.

{% highlight csharp %}
using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var isSuccess = connection.Update(new Invoice { InvoiceID = 1, Code = "Update_Single_1"});
}
{% endhighlight %}

## Example - Update Many
UPDATE many entities.

{% highlight csharp %}
using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var list = new List<Invoice>()
    {
        new Invoice {InvoiceID = 1, Code = "Update_Many_1"},
        new Invoice {InvoiceID = 2, Code = "Update_Many_2"},
        new Invoice {InvoiceID = 3, Code = "Update_Many_3"}
    };

    var isSuccess = connection.Update(list);
}
{% endhighlight %}
