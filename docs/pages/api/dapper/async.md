---
layout: default
title: Dapper - Async
permalink: async
---

{% include template-h1.html %}

## Description
Dapper also extend the IDbConnection interface with Async (asynchronous) methods:
- [ExecuteAsync](#executeasync)
- [QueryAsync](#queryasync)
- [QueryFirstAsync](#queryfirstasync)
- [QueryFirstOrDefaultAsync](#queryfirstordefaultasync)
- [QuerySingleAsync](#querysingleasync)
- [QuerySingleOrDefaultAsync](#querysingleordefaultasync)
- [QueryMultipleAsync](#querymultipleasync)

> We only added non-asynchronous version in this tutorial to make it easier to read.

## ExecuteAsync
{% highlight csharp %}
var sql = "Invoice_Insert";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var affectedRows = connection.ExecuteAsync(sql,
			new {Kind = InvoiceKind.WebInvoice, Code = "Single_Insert_1"},
			commandType: CommandType.StoredProcedure)
		.Result;
}
{% endhighlight %}

## QueryAsync
{% highlight csharp %}
var sql = "Invoice_Insert";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var invoices = connection.QueryAsync<Invoice>(sql).Result.ToList();
}
{% endhighlight %}

## QueryFirstAsync
{% highlight csharp %}
var sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var invoice = connection.QueryFirstAsync<Invoice>(sql, new {InvoiceID = 1}).Result;
}
{% endhighlight %}

## QueryFirstOrDefaultAsync
{% highlight csharp %}
var sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var invoice = connection.QueryFirstOrDefaultAsync<Invoice>(sql, new {InvoiceID = 1}).Result;
}
{% endhighlight %}

## QuerySingleAsync
{% highlight csharp %}
var sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var invoice = connection.QuerySingleAsync<Invoice>(sql, new {InvoiceID = 1}).Result;
}
{% endhighlight %}

## QuerySingleOrDefaultAsync
{% highlight csharp %}
var sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var invoice = connection.QuerySingleOrDefaultAsync<Invoice>(sql, new {InvoiceID = 1}).Result;
}
{% endhighlight %}

## QueryMultipleAsync
{% highlight csharp %}
var sql = "SELECT * FROM Invoice; SELECT * FROM InvoiceItem;";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	using (var multi = connection.QueryMultipleAsync(sql, new { InvoiceID = 1 }).Result)
	{
		var invoice = multi.Read<Invoice>().First();
		var invoiceItems = multi.Read<InvoiceItem>().ToList();
	}
}
{% endhighlight %}


