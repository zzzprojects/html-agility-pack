# Save

## public void Save(Stream outStream)

Saves the HTML document to the specified stream. Save method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

outStream: The stream to which you want to save.

### Example

The following example saves the HTML document to the specified stream.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);
		
FileStream sw = new FileStream("FileStream.html", FileMode.Create);

htmlDoc.Save(sw);

```

Click [here](https://dotnetfiddle.net/e3GYpK) to run this example.

## public void Save(StreamWriter writer)

Saves the HTML document to the specified StreamWriter. Save method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

writer: The StreamWriter to which you want to save.

### Example

The following example saves the HTML document to the specified StreamWriter.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);
		
StreamWriter sw = new StreamWriter("StreamWriter.html");

htmlDoc.Save(sw);

```

Click [here](https://dotnetfiddle.net/nyt6gY) to run this example.

## public void Save(TextWriter writer)

Saves the HTML document to the specified TextWriter. Save method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

writer: The TextWriter to which you want to save.

### Example

The following example saves the HTML document to the specified TextWriter.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);
		
TextWriter tw = File.CreateText("TextWriter.html");

htmlDoc.Save(tw);

```

Click [here](https://dotnetfiddle.net/98wejH) to run this example.

## public void Save(string filename)

Saves the mixed document to the specified file. Save method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

filename: The location of the file where you want to save the document.

### Example

The following example saves the mixed document to the specified file.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

htmlDoc.Save("test.html");

```

Click [here](https://dotnetfiddle.net/uke1Bg) to run this example.

## public void Save(XmlWriter writer)

Saves the HTML document to the specified XmlWriter. Save method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

writer: The XmlWriter to which you want to save.

### Example

The following example saves the HTML document to the specified XmlWriter.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);
		
htmlDoc.OptionOutputAsXml = true;

StringWriter sw = new StringWriter();
	
XmlTextWriter xw = new XmlTextWriter(sw);
	
htmlDoc.Save(xw);

```

Click [here](https://dotnetfiddle.net/CCZ2Gu) to run this example.

## public void Save(Stream outStream, Encoding encoding)

Saves the HTML document to the specified stream using character encoding. Save method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

outStream: The stream to which you want to save. May not be null.
encoding: The character encoding to use. May not be null.

### Example

The following example saves the HTML document to the specified stream using character encoding.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);
		
FileStream sw = new FileStream("FileStream.html", FileMode.Create);

htmlDoc.Save(sw, Encoding.UTF8);

```

Click [here](https://dotnetfiddle.net/fyDMJt) to run this example.

## public void Save(string filename, Encoding encoding)

Saves the mixed document to the specified file using character encoding. Save method is a member of **HtmlAgilityPack.HtmlDocument**

### Parameters:

filename: The location of the file where you want to save the document.
encoding: The character encoding to use. May not be null.

### Example

The following example saves the mixed document to the specified file using character encoding.

```csharp

var htmlDoc = new HtmlDocument();
htmlDoc.LoadHtml(html);

htmlDoc.Save("test.html", Encoding.UTF8);

```

Click [here](https://dotnetfiddle.net/IRTOcM) to run this example.
