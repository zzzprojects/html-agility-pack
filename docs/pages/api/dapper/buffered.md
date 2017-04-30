---
layout: default
title: Dapper - Buffered
permalink: buffered
---

{% include template-h1.html %}

## Description

- Default: True

A buffered query return the entire reader at once. That is ideal in most scenario.

A non-buffered query is equivalent as streaming. You only load objects on demand. That can be useful for a very large query to reduce memory usage.

{% highlight csharp %}
string sqlInvoices = "SELECT * FROM Invoice;";

using (var connection = My.ConnectionFactory())
{
	var invoices = connection.Query<Invoice>(sqlInvoices, buffered: false).ToList();
}
{% endhighlight %}
