---
layout: default
title: Dapper - Result Multi-Result 
permalink: result-multi-result
---

{% include template-h1.html %}

## Description
QueryMultiple method is an extension method which can be called from any object of type IDbConnection. It can execute multiple queries within the same command and map results.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice WHERE InvoiceID = @InvoiceID; SELECT * FROM InvoiceItem WHERE InvoiceID = @InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    using (var multi = connection.QueryMultiple(sql, new {InvoiceID = 1}))
    {
        var invoice = multi.Read<Invoice>().First();
        var invoiceItems = multi.Read<InvoiceItem>().ToList();
    }
}
{% endhighlight %}
