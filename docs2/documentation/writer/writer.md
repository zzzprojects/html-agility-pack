# HTML Writer

Save HtmlDocument && Write HtmlNode

## HtmlDocument - Methods

| Name | Description |
| :--- | :---------- |
| [Save(Stream)](save) | Saves the HTML document to the specified stream. |
| [Save(StreamWriter)](save#public-void-savestreamwriter-writer) | Saves the HTML document to the specified StreamWriter. |
| [Save(TextWriter)](save#public-void-savetextwriter-writer) | Saves the HTML document to the specified TextWriter. |
| [Save(String)](save#public-void-savestring-filename) | Saves the mixed document to the specified file. |
| [Save(XmlWriter)](save#public-void-savexmlwriter-writer) | Saves the HTML document to the specified XmlWriter. |
| [Save(Stream, Encoding)](save#public-void-savestream-outstream-encoding-encoding) | Saves the HTML document to the specified stream. |
| [Save(String, Encoding)](save#public-void-savestring-filename-encoding-encoding) | Saves the mixed document to the specified file. |

## HtmlNode - Methods

| Name | Description |
| :--- | :---------- |
| [WriteContentTo()](write-content-to) | Saves all the children of the node to a string. |
| [WriteContentTo(TextWriter)](write-content-to#public-void-writecontenttotextwriter-outtext-int-level--0) | Saves all the children of the node to the specified TextWriter. |
| [WriteTo()](write-to) | Saves the current node to a string. |
| [WriteTo(TextWriter)](write-to#public-void-writetotextwriter-outtext-int-level--0) | Saves the current node to the specified TextWriter. |
| [WriteTo(XmlWriter)](write-to#public-void-writetoxmlwriter-writer) | Saves the current node to the specified XmlWriter. |
