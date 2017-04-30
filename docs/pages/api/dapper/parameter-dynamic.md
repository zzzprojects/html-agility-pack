---
layout: default
title: Dapper - Parameter Dynamic 
permalink: parameter-dynamic
---

{% include template-h1.html %}

## Description
Create and use a parameter in a Dapper method.

### Single
Execute a single time a SQL Command.

{% highlight csharp %}
var sql = "EXEC Invoice_Insert";

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	DynamicParameters parameter = new DynamicParameters();

	parameter.Add("@Kind", InvoiceKind.WebInvoice, DbType.Int32, ParameterDirection.Input);
	parameter.Add("@Code", "Many_Insert_0", DbType.String, ParameterDirection.Input);
	parameter.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

	connection.Execute(sql,
		parameter,
		commandType: CommandType.StoredProcedure);

	int rowCount = parameter.Get<int>("@RowCount");
}
{% endhighlight %}

### Many
Execute many times a SQL Command

{% highlight csharp %}
var sql = "EXEC Invoice_Insert";

var parameters = new List<DynamicParameters>();

for (var i = 0; i < 3; i++)
{
	var p = new DynamicParameters();
	p.Add("@Kind", InvoiceKind.WebInvoice, DbType.Int32, ParameterDirection.Input);
	p.Add("@Code", "Many_Insert_" + (i + 1), DbType.String, ParameterDirection.Input);
	p.Add("@RowCount", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

	parameters.Add(p);
}

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	connection.Execute(sql,
		parameters,
		commandType: CommandType.StoredProcedure
	);

	var rowCount = parameters.Sum(x => x.Get<int>("@RowCount"));
}
{% endhighlight %}
