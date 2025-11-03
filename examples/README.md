# HtmlAgilityPack

<img width="1916" height="911" alt="image" src="https://github.com/user-attachments/assets/31b0fd27-3fcf-446b-aaec-4c8235bf29b0" />

## One-Click Development Environment

[![Open in GitHub Codespaces](https://github.com/codespaces/badge.svg)](https://github.com/codespaces/new?hide_repo_select=true&ref=main&repo=Ivy-Interactive%2FIvy-Examples&machine=standardLinux32gb&devcontainer_path=.devcontainer%2Fhtmlagilitypack%2Fdevcontainer.json&location=EuropeWest)

Click the badge above to open Ivy Examples repository in GitHub Codespaces with:
- **.NET 9.0** SDK pre-installed
- **Ready-to-run** development environment
- **No local setup** required

## Created Using Ivy

Web application created using [Ivy-Framework](https://github.com/Ivy-Interactive/Ivy-Framework).

**Ivy** - The ultimate framework for building internal tools with LLM code generation by unifying front-end and back-end into a single C# codebase. With Ivy, you can build robust internal tools and dashboards using C# and AI assistance based on your existing database.

Ivy is a web framework for building interactive web applications using C# and .NET.

## Interactive Example For HTML Parsing

This example demonstrates HTML parsing operations using the [HtmlAgilityPack library](https://github.com/zzzprojects/html-agility-pack) integrated with Ivy. HtmlAgilityPack is a free and open-source HTML parser written in C# to read/write DOM and supports plain XPATH or XSLT.

**What This Application Does:**

This specific implementation creates a **Website Analyzer** application that allows users to:

- **Parse Any Website**: Enter a URL to analyze any website's HTML structure and content
- **Extract Website Data**: Get title, meta descriptions, images, page structure, and social media links
- **Selective Data Extraction**: Choose which types of data to extract using toggle controls
- **Social Media Detection**: Automatically identify social media links (Discord, GitHub, YouTube, LinkedIn, X/Twitter, etc.)
- **Structured Results**: View organized data in expandable sections for easy navigation
- **Real-time Analysis**: Get instant results with loading indicators and error handling

**Technical Implementation:**

- Uses HtmlAgilityPack's `HtmlWeb` and `HtmlDocument` for robust HTML parsing
- Implements selective data extraction with toggle-based UI controls
- Generates structured results with expandable sections for better organization
- Handles social media link detection with comprehensive domain matching
- Creates responsive horizontal layout with form controls and results display
- Supports error handling with user-friendly messages and validation
- Separates social media links from external links for better categorization

## How to Run

1. **Prerequisites**: .NET 9.0 SDK
2. **Navigate to the example**:
   ```bash
   cd htmlagilitypack
   ```
3. **Restore dependencies**:
   ```bash
   dotnet restore
   ```
4. **Run the application**:
   ```bash
   dotnet watch
   ```
5. **Open your browser** to the URL shown in the terminal (typically `http://localhost:5010`)

## How to Deploy

Deploy this example to Ivy's hosting platform:

1. **Navigate to the example**:
   ```bash
   cd htmlagilitypack
   ```
2. **Deploy to Ivy hosting**:
   ```bash
   ivy deploy
   ```
This will deploy your HTML parser application with a single command.

## Learn More

- HtmlAgilityPack for .NET overview: [github.com/zzzprojects/html-agility-pack](https://github.com/zzzprojects/html-agility-pack)
- Ivy Documentation: [docs.ivy.app](https://docs.ivy.app)