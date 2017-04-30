---
layout: default
title: Dapper - Result Multi-Mapping 
permalink: result-multi-mapping
---

{% include template-h1.html %}

## Description
Extension methods can be used to execute a query and map the result to a strongly typed list with relations.

The relation can be either:
- [One to One](#example---query-multi-mapping-one-to-one)
- [One to Many](#example---query-multi-mapping-one-to-many)

These extension methods can be called from any object of type IDbConnection.
## Example - Query Multi-Mapping (One to One)
Query method can execute a query and map the result to a strongly typed list with a one to one relation.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice AS A INNER JOIN InvoiceDetail AS B ON A.InvoiceID = B.InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoices = connection.Query<Invoice, InvoiceDetail, Invoice>(
            sql,
            (invoice, invoiceDetail) =>
            {
                invoice.InvoiceDetail = invoiceDetail;
                return invoice;
            },
            splitOn: "InvoiceID")
        .Distinct()
        .ToList();
}
{% endhighlight %}

## Example - Query Multi-Mapping (One to Many)
Query method can execute a query and map the result to a strongly typed list with a one to many relations.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice AS A INNER JOIN InvoiceItem AS B ON A.InvoiceID = B.InvoiceID;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoiceDictionary = new Dictionary<int, Invoice>();

    var invoices = connection.Query<Invoice, InvoiceItem, Invoice>(
            sql,
            (invoice, invoiceItem) =>
            {
                Invoice invoiceEntry;
                
                if (!invoiceDictionary.TryGetValue(invoice.InvoiceID, out invoiceEntry))
                {
                    invoiceEntry = invoice;
                    invoiceEntry.Items = new List<InvoiceItem>();
                    invoiceDictionary.Add(invoiceEntry.InvoiceID, invoiceEntry);
                }

                invoiceEntry.Items.Add(invoiceItem);
                return invoiceEntry;
            },
            splitOn: "InvoiceID")
        .Distinct()
        .ToList();
}
{% endhighlight %}
