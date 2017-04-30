---
layout: default
title: Dapper Contrib - Data Annotation - Write
permalink: data-annotation-write
---

{% include template-h1.html %}

## Description
Specifie if the property is writable or not.

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

	// The FakeProperty is null
}
{% endhighlight %}
