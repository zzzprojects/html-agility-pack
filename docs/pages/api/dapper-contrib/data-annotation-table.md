---
layout: default
title: Dapper Contrib - Data Annotation - Table
permalink: data-annotation-table
---

{% include template-h1.html %}

## Description
Specifie the destination table name mapped to the entity.

{% highlight csharp %}
[Table("Invoice")]
public class InvoiceContrib
{
	[Key]
	public int InvoiceID { get; set; }

	public string Code { get; set; }
	public InvoiceKind Kind { get; set; }

	[Write(false)]
	[Computed]
	public string FakeProperty { get; set; }
}

using (var connection = My.ConnectionFactory())
{
	connection.Open();

	var invoice = connection.Get<InvoiceContrib>(1);
}
{% endhighlight %}
