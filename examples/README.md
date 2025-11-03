# HtmlAgilityPack Example

This example demonstrates HTML parsing operations using the [HtmlAgilityPack library](https://github.com/zzzprojects/html-agility-pack). HtmlAgilityPack is a free and open-source HTML parser written in C# to read/write DOM and supports plain XPATH or XSLT.

## What This Application Does

This example creates a **Website Analyzer** application that allows users to:

- **Parse Any Website**: Enter a URL to analyze any website's HTML structure and content
- **Extract Website Data**: Get title, meta descriptions, images, page structure, and social media links
- **Selective Data Extraction**: Choose which types of data to extract using toggle controls
- **Social Media Detection**: Automatically identify social media links (Discord, GitHub, YouTube, LinkedIn, X/Twitter, etc.)
- **Structured Results**: View organized data in expandable sections for easy navigation
- **Real-time Analysis**: Get instant results with loading indicators and error handling

## Technical Implementation

- Uses HtmlAgilityPack's `HtmlWeb` and `HtmlDocument` for robust HTML parsing
- Implements selective data extraction with toggle-based UI controls
- Generates structured results with expandable sections for better organization
- Handles social media link detection with comprehensive domain matching
- Creates responsive horizontal layout with form controls and results display
- Supports error handling with user-friendly messages and validation
- Separates social media links from external links for better categorization

## Prerequisites

- **.NET 9.0 SDK** or later
- This example uses the [Ivy Framework](https://github.com/Ivy-Interactive/Ivy-Framework) for the web UI

> **Note**: This example requires .NET 9.0 SDK. Make sure you have it installed before running the application.

## How to Run

1. **Navigate to the example directory**:

   ```bash
   cd examples
   ```

2. **Restore dependencies**:

   ```bash
   dotnet restore
   ```

3. **Run the application**:

   ```bash
   dotnet watch
   ```

4. **Open your browser** to the URL shown in the terminal (typically `http://localhost:5010`)

## Learn More

- HtmlAgilityPack Documentation: [html-agility-pack.net](https://html-agility-pack.net/)
- HtmlAgilityPack Repository: [github.com/zzzprojects/html-agility-pack](https://github.com/zzzprojects/html-agility-pack)
- Ivy Framework: [github.com/Ivy-Interactive/Ivy-Framework](https://github.com/Ivy-Interactive/Ivy-Framework)
- Ivy Documentation: [docs.ivy.app](https://docs.ivy.app)
