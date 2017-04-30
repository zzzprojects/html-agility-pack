---
layout: default
title: Dapper Contrib - DeleteAll
permalink: deleteall
---

{% include template-h1.html %}

## Description
DELETE ALL entities.

{% highlight csharp %}
using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var isSuccess = connection.DeleteAll<Invoice>();
}
{% endhighlight %}
