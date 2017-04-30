---
layout: default
title: Dapper - Parameter Anonymous 
permalink: parameter-anonymous
---

{% include template-h1.html %}

## Description
Dapper make it simple & safe (SQL Injection) to use parameter by supporting anonymous type.

### Single
Execute a single time a SQL Command.

{% highlight csharp %}
var sql = "EXEC Invoice_Insert";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var affectedRows = connection.Execute(sql,
        new {Kind = InvoiceKind.WebInvoice, Code = "Single_Insert_1"},
        commandType: CommandType.StoredProcedure);

    My.Result.Show(affectedRows);
}
{% endhighlight %}

### Many
Execute many times a SQL Command

{% highlight csharp %}
var sql = "EXEC Invoice_Insert";

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
}
{% endhighlight %}
