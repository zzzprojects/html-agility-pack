---
layout: default
title: Dapper - Parameter List 
permalink: parameter-list
---

{% include template-h1.html %}

## Description
Dapper allow you to specify multiple parameter on a IN clause by using a list.

{% highlight csharp %}
var sql = "SELECT * FROM Invoice WHERE Kind IN @Kind;";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var invoices = connection.Query<Invoice>(sql, new {Kind = new[] {InvoiceKind.StoreInvoice, InvoiceKind.WebInvoice}}).ToList();
}

{% endhighlight %}
