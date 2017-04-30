---
layout: default
title: Dapper Plus
permalink: dapper-plus
---

{% include template-h1.html %}

## What's Dapper Plus?
Dapper Plus extend the IDbConnection interface with Bulk Operations methods:

- Bulk Insert
- Bulk Update
- Bulk Delete
- Bulk Merge

This library is the **fastest  way** to perform saving operations in a database.

Official Website: <a href="http://dapper-plus.net/" target="_blank">http://dapper-plus.net/</a>

## Installation
Dapper Plus is installed through NuGet: <a href="https://www.nuget.org/packages/Z.Dapper.Plus/" target="_blank">https://www.nuget.org/packages/Z.Dapper.Plus/</a>

This library is **NOT FREE**, but a monthly trial is available at the start of every month.

## Requirement
Dapper Plus is compatible with all major database provider:

- SQL Server 2008+
- SQL Azure
- SQL Compact
- Oracle
- MySQL
- SQLite
- PostgreSQL

## Methods
Dapper Plus extend your IDbConnection interface with multiple methods:

- [Bulk Insert](/bulk-insert)
- [Bulk Update](/bulk-update)
- [Bulk Delete](/bulk-delete)
- [Bulk Merge](/bulk-merge)

{% highlight csharp %}
// Bulk Insert
connection.BulkInsert(invoices)
	.ThenForEach(x => x.Items.ForEach(y => y.InvoiceID = x.InvoiceID))
	.ThenBulkInsert(x => x.Items);
  
// Bulk Update
connection.BulkUpdate(invoices, x => x.Items);

// Bulk Delete
connection.BulkDelete(invoices.SelectMany(x => x.Items))
	.BulkDelete(invoices);

// Bulk Merge
connection.BulkMerge(invoices)
	.ThenForEach(x => x.Items.ForEach(y => y.InvoiceID = x.InvoiceID))
	.ThenBulkMerge(x => x.Items);
  
{% endhighlight %}

