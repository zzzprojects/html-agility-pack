---
layout: default
title: Dapper - Parameter String 
permalink: parameter-string
---

{% include template-h1.html %}

## Description

{% highlight csharp %}
var sql = "SELECT * FROM Invoice WHERE Code = @Code;";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var invoices = connection.Query<Invoice>(sql, new {Code = new DbString {Value = "Invoice_1", IsFixedLength = false, Length = 9, IsAnsi = true}}).ToList();

	My.Result.Show(invoices);
}
{% endhighlight %}
