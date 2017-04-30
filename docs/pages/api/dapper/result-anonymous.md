---
layout: default
title: Dapper - Result Anonymous 
permalink: result-anonymous
---

{% include template-h1.html %}

## Description
Extension methods can be used to execute a query and map the result using dynamic.

The anonymous result can be mapped from following extension methods:

- [Query](#example---query)
- [QueryFirst](#example---queryfirst)
- [QueryFirstOrDefault](#example---queryfirstordefault)
- [QuerySingle](#example---querysingle)
- [QuerySingleOrDefault](#example---querysingleordefault)

These extension methods can be called from any object of type IDbConnection.
## Example - Query
Query method can execute a query and map the result to a dynamic list.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoices = connection.Query(sql).ToList();
}
{% endhighlight %}

## Example - QueryFirst
QueryFirst method can execute a query and map the first result to a dynamic list.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoice = connection.QueryFirst(sql, new {InvoiceID = 1});
}
{% endhighlight %}

## Example - QueryFirstOrDefault
QueryFirstOrDefault method can execute a query and map the first result to a dynamic list, or a default value if the sequence contains no elements.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoice = connection.QueryFirstOrDefault(sql, new {InvoiceID = 1});
}
{% endhighlight %}

## Example - QuerySingle
QuerySingle method can execute a query and map the first result to a dynamic list, and throws an exception if there is not exactly one element in the sequence.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoice = connection.QuerySingle(sql, new {InvoiceID = 1});
}
{% endhighlight %}

## Example - QuerySingleOrDefault
QuerySingleOrDefault method can execute a query and map the first result to a dynamic list, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoice = connection.QuerySingleOrDefault(sql, new {InvoiceID = 1});
}
{% endhighlight %}
