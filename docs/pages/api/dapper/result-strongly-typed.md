---
layout: default
title: Dapper - Result Strongly Typed 
permalink: result-strongly-typed
---

{% include template-h1.html %}

## Description
Extension methods can be used to execute a query and map the result using strongly typed.

The anonymous result can be mapped from following methods:

- [Query](#example---query)
- [QueryFirst](#example---queryfirst)
- [QueryFirstOrDefault](#example---queryfirstordefault)
- [QuerySingle](#example---querysingle)
- [QuerySingleOrDefault](#example---querysingleordefault)

These extension methods can be called from any object of type IDbConnection.
## Example - Query
Query method can execute a query and map the result to a strongly typed list.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoices = connection.Query<Invoice>(sql).ToList();
}
{% endhighlight %}

## Example - QueryFirst
QueryFirst method can execute a query and map the first result to a strongly typed list.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoice = connection.QueryFirst<Invoice>(sql, new {InvoiceID = 1});
}
{% endhighlight %}

## Example - QueryFirstOrDefault
QueryFirstOrDefault method can execute a query and map the first result to a strongly typed list, or a default value if the sequence contains no elements.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoice = connection.QueryFirstOrDefault<Invoice>(sql, new {InvoiceID = 1});
}
{% endhighlight %}

## Example - QuerySingle
QuerySingle method can execute a query and map the first result to a strongly typed list, and throws an exception if there is not exactly one element in the sequence.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoice = connection.QuerySingle<Invoice>(sql, new {InvoiceID = 1});
}
{% endhighlight %}

## Example - QuerySingleOrDefault
QuerySingleOrDefault method can execute a query and map the first result to a strongly typed list, or a default value if the sequence is empty; this method throws an exception if there is more than one element in the sequence.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoice = connection.QuerySingleOrDefault<Invoice>(sql, new {InvoiceID = 1});
}
{% endhighlight %}
