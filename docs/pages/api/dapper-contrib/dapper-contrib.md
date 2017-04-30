---
layout: default
title: Dapper Contrib
permalink: dapper-contrib
---

{% include template-h1.html %}


## What's Dapper Contrib?
Dapper Contrib extend the IDbConnection interface with additional CRUD methods.

## Installation
Dapper Contrib is installed through NuGet: <a href="https://www.nuget.org/packages/Dapper.Contrib/" target="_blank">https://www.nuget.org/packages/Dapper.Contrib/</a>

## Methods
Dapper Contrib extend your IDbConnection interface with additional CRUD methods:

- [Get](/get)
- [GetAll](/getall)
- [Insert](/insert)
- [Update](/update)
- [Delete](/delete)
- [DeleteAll](/deleteall)

{% highlight csharp %}
var invoice = connection.Get<InvoiceContrib>(1);
var invoices = connection.GetAll<InvoiceContrib>().ToList();
var identity = connection.Insert(new InvoiceContrib {Kind = InvoiceKind.WebInvoice, Code = "Insert_Single_1"});
var isSuccess = connection.Update(new InvoiceContrib {InvoiceID = 1, Code = "Update_Single_1"});
var isSuccess = connection.Delete(new InvoiceContrib {InvoiceID = 1});
var isSuccess = connection.DeleteAll<InvoiceContrib>();
{% endhighlight %}


## Data Annotations
Dapper Contrib allow mapping using Data Annotations:

- [Key](data-annotation-key)
- [ExplicitKey](data-annotation-explicitkey)
- [Table](data-annotation-table)
- [Write](data-annotation-write)
- [Computed](data-annotation-computed)

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

[Table("InvoiceDetail")]
public class InvoiceDetailContrib
{
	[ExplicitKey]
	public int InvoiceID { get; set; }

	public string Detail { get; set; }
}
{% endhighlight %}
