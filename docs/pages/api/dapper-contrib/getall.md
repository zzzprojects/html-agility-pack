---
layout: default
title: Dapper Contrib - GetAll
permalink: getall
---

{% include template-h1.html %}

## Description
GET ALL entities.

{% highlight csharp %}
using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoices = connection.GetAll<Invoice>().ToList();
}
{% endhighlight %}
