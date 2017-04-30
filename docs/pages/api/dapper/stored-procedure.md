---
layout: default
title: Dapper - Stored Procedure 
permalink: stored-procedure
---

{% include template-h1.html %}

## Description
Using Stored Procedure in Dapper is very easy, you simply need to specify the command type

### Execute Single
Execute a Stored Procedure a single time.

{% highlight csharp %}
var sql = "Invoice_Insert";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var affectedRows = connection.Execute(sql,
		new {Kind = InvoiceKind.WebInvoice, Code = "Single_Insert_1"},
		commandType: CommandType.StoredProcedure);

	My.Result.Show(affectedRows);
}
{% endhighlight %}

### Execute Many
Execute a Stored Procedure multiple times.

{% highlight csharp %}
var sql = "Invoice_Insert";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var affectedRows = connection.Execute(sql,
		new[]
		{
			new {Kind = InvoiceKind.WebInvoice, Code = "Many_Insert_1"},
			new {Kind = InvoiceKind.WebInvoice, Code = "Many_Insert_2"},
			new {Kind = InvoiceKind.StoreInvoice, Code = "Many_Insert_3"}
		},
		commandType: CommandType.StoredProcedure
	);

	My.Result.Show(affectedRows);
}
{% endhighlight %}
