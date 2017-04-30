---
layout: default
title: Dapper - Query 
permalink: query
---

{% include template-h1.html %}

## Description
Query method is an extension method which can be called from any object of type IDbConnection. It can execute a query and map the result.

The result can be mapped to:

- [Anonymous](#example---query-anonymous)
- [Strongly Typed](#example---query-strongly-typed)
- [Multi-Mapping (One to One)](#example---query-multi-mapping-one-to-one)
- [Multi-Mapping (One to Many)](#example---query-multi-mapping-one-to-many)
- [Multi-Type](#example---query-multi-type)

### Parameters
The following table shows different parameter of an Query method.

| Name | Description |
| :--- | :---------- |
| sql         | The query to execute. |
| param       | The query parameters (default = null). |
| transaction | The transaction to use (default = null). |
| buffered    | True to buffer readeing the results of the query (default = true). |
| commandTimeout | The command timeout (default = null) |
| commandType    | The command type (default = null) |

## Example - Query Anonymous
Raw SQL query can be executed using Query method and map the result to a dynamic list.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoices = connection.Query(sql).ToList();
    
    My.Result.Show(invoices);
}
{% endhighlight %}
<img src="images/3-anonynous-entity.png" alt="Query Anonymous" />

## Example - Query Strongly Typed
Raw SQL query can be executed using Query method and map the result to a strongly typed list.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoices = connection.Query<Invoice>(sql).ToList();
    
    My.Result.Show(invoices);
}
{% endhighlight %}
<img src="images/3-invoices.png" alt="Query Strongly Typed" />

## Example - Query Multi-Mapping (One to One)
Raw SQL query can be executed using Query method and map the result to a strongly typed list with a one to one relation.

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
        
    My.Result.Show(invoices);
}
{% endhighlight %}
<img src="images/3-invoices-included-invoicedetail.png" alt="One to One" />

## Example - Query Multi-Mapping (One to Many)
Raw SQL query can be executed using Query method and map the result to a strongly typed list with a one to many relations.

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
        
    My.Result.Show(invoices);
}
{% endhighlight %}
<img src="images/3-invoices-included-invoiceitem.png" alt="One to Many" />

## Example - Query Multi-Type
Raw SQL query can be executed using Query method and map the result to a list of different types.

{% highlight csharp %}
string sql = "SELECT * FROM Invoice;";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var invoices = new List<Invoice>();

    using (var reader = connection.ExecuteReader(sql))
    {
        var storeInvoiceParser = reader.GetRowParser<StoreInvoice>();
        var webInvoiceParser = reader.GetRowParser<WebInvoice>();

        while (reader.Read())
        {
            Invoice invoice;

            switch ((InvoiceKind) reader.GetInt32(reader.GetOrdinal("Kind")))
            {
                case InvoiceKind.StoreInvoice:
                    invoice = storeInvoiceParser(reader);
                    break;
                case InvoiceKind.WebInvoice:
                    invoice = webInvoiceParser(reader);
                    break;
                default:
                    throw new Exception(ExceptionMessage.GeneralException);
            }

            invoices.Add(invoice);
        }
    }
    
    My.Result.Show(invoices);
}
{% endhighlight %}
<img src="images/3-invoices-with-storeinvoice-webinvoice.png" alt="Query Multi-Type" />
