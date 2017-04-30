---
layout: default
title: Dapper - Execute 
permalink: execute
---

{% include template-h1.html %}

## Description
Execute is an extension method which can be called from any object of type IDbConnection. It can execute a command one or multiple times and return the number of affected rows. This method is usually used to execute:
- [Stored Procedure](#example---execute-stored-procedure)
- [INSERT statement](#example---execute-insert)
- [UPDATE statement](#example---execute-update)
- [DELETE statement](#example---execute-delete)

### Parameters
The following table shows different parameter of an Execute method.

| Name | Description |
| :--- | :---------- |
| sql            | The command text to execute. |
| param          | The command parameters (default = null). |
| transaction    | The transaction to use (default = null). |
| commandTimeout | The command timeout (default = null) |
| commandType    | The command type (default = null) |

## Example - Execute Stored Procedure

### Single
Execute the Stored Procedure a single time.

{% highlight csharp %}
string sql = "EXEC Invoice_Insert";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var affectedRows = connection.Execute(sql,
        new {Kind = InvoiceKind.WebInvoice, Code = "Single_Insert_1"},
        commandType: CommandType.StoredProcedure);

    My.Result.Show(affectedRows);
}
{% endhighlight %}

<img src="images/3-anonynous-entity.png" alt="Stored Procedure Single" />

### Many
Execute the Stored Procedure multiple times. Once for every object in the array list.

{% highlight csharp %}
string sql = "EXEC Invoice_Insert";

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

## Example - Execute INSERT

### Single
Execute the INSERT Statement a single time.

{% highlight csharp %}
string sql = "INSERT INTO Invoice (Code) Values (@Code);";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var affectedRows = connection.Execute(sql, new {Kind = InvoiceKind.WebInvoice, Code = "Single_Insert_1"});

    My.Result.Show(affectedRows);
}
{% endhighlight %}

### Many
Execute the INSERT Statement multiple times. Once for every object in the array list.

{% highlight csharp %}
string sql = "INSERT INTO Invoice (Code) Values (@Code);";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var affectedRows = connection.Execute(sql,
        new[]
        {
            new {Kind = InvoiceKind.WebInvoice, Code = "Many_Insert_1"},
            new {Kind = InvoiceKind.WebInvoice, Code = "Many_Insert_2"},
            new {Kind = InvoiceKind.StoreInvoice, Code = "Many_Insert_3"}
        }
    );

    My.Result.Show(affectedRows);
}
{% endhighlight %}

## Example - Execute UPDATE

### Single
Execute the UPDATE Statement a single time.

{% highlight csharp %}
string sql = "UPDATE Invoice SET Code = @Code WHERE InvoiceID = @InvoiceID";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var affectedRows = connection.Execute(sql, new {InvoiceID = 1, Code = "Single_Update_1"});

    My.Result.Show(affectedRows);
}
{% endhighlight %}

### Many
Execute the UPDATE Statement multiple times. Once for every object in the array list.

{% highlight csharp %}
string sql = "UPDATE Invoice SET Code = @Code WHERE InvoiceID = @InvoiceID";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var affectedRows = connection.Execute(sql,
        new[]
        {
            new {InvoiceID = 1, Code = "Many_Update_1"},
            new {InvoiceID = 2, Code = "Many_Update_2"},
            new {InvoiceID = 3, Code = "Many_Update_3"}
        });

    My.Result.Show(affectedRows);
}
{% endhighlight %}

## Example - Execute DELETE

### Single
Execute the DELETE Statement a single time.

{% highlight csharp %}
string sql = "DELETE FROM Invoice WHERE InvoiceID = @InvoiceID";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var affectedRows = connection.Execute(sql, new {InvoiceID = 1});

    My.Result.Show(affectedRows);
}
{% endhighlight %}

### Many
Execute the DELETE Statement multiple times. Once for every object in the array list.

{% highlight csharp %}
string sql = "DELETE FROM Invoice WHERE InvoiceID = @InvoiceID";

using (var connection = My.ConnectionFactory())
{
    connection.Open();

    var affectedRows = connection.Execute(sql,
        new[]
        {
            new {InvoiceID = 1},
            new {InvoiceID = 2},
            new {InvoiceID = 3}
        });
}
{% endhighlight %}
