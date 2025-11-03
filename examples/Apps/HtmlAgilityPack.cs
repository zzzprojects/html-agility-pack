namespace HtmlAgilityPack.Apps;

using HtmlAgilityPack;

[App(icon: Icons.Code, title: "HtmlAgilityPack")]
public class HtmlAgilityPackApp : ViewBase
{
    public override object? Build()
    {
        var urlState = UseState("https://html-agility-pack.net/");
        var urlMetaState = UseState<string>("");
        var urlLinksState = UseState<string>("");
        var urlTitleState = UseState<string>("");
        var urlImagesState = UseState<string>("");
        var urlStructureState = UseState<string>("");
        var urlSocialState = UseState<string>("");
        var errorState = UseState<string>("");
        var parsingState = UseState(false);
        
        // Data type selection
        var dataTypesSelect = UseState<string[]>(new[] { "title", "meta", "images", "structure", "social", "links" });
        var dataTypeOptions = new[] { "title", "meta", "images", "structure", "social", "links" }.ToOptions();

        HtmlDocument? document = null;
        var loadURL = (string url) =>
        {
            var webGet = new HtmlWeb();
            try
            {
                document = webGet.Load(url);
            }
            catch (Exception) //invalid url
            {
                return;
            }
        };

        var getTitleData = () =>
        {
            if (document == null)
                return string.Empty;
            string title = string.Empty;
            var titleNode = document.DocumentNode.SelectSingleNode("//head/title");
            if (titleNode != null)
            {
                title = titleNode.InnerText.Trim();
            }
            return title;
        };

        var getMetaData = () =>
        {
            if (document == null)
                return string.Empty;
            string meta = string.Empty;
            var metaTags = document.DocumentNode.SelectNodes("//meta");
            if (metaTags != null)
            {
                foreach (var tag in metaTags)
                {
                    if (tag.Attributes["name"] != null && tag.Attributes["content"] != null && tag.Attributes["name"].Value.ToLower() == "description")
                    {
                        meta += tag.Attributes["content"].Value + System.Environment.NewLine;
                    }
                }
            }
            else
            {
                meta = string.Empty;
            }
            return meta;
        };

        var getLinksData = () =>
        {
            if (document == null)
                return string.Empty;
            string links = string.Empty;
            var socialDomains = new[] { 
                "facebook.com", "twitter.com", "x.com", "linkedin.com", "instagram.com", 
                "youtube.com", "tiktok.com", "discord.gg", "discord.com", "github.com",
                "reddit.com", "pinterest.com", "snapchat.com", "telegram.org", "whatsapp.com",
                "discord.gg/", "github.com/"
            };
            
            var metaTags = document.DocumentNode.SelectNodes("//a");
            if (metaTags != null)
            {
                foreach (var tag in metaTags)
                {
                    var href = tag.Attributes["href"]?.Value ?? "";
                    if (!string.IsNullOrEmpty(href) && (href.StartsWith("https://") || href.StartsWith("http://")))
                    {
                        // Check if it's not a social media link
                        bool isSocialLink = false;
                        foreach (var domain in socialDomains)
                        {
                            if (href.Contains(domain))
                            {
                                isSocialLink = true;
                                break;
                            }
                        }
                        
                        if (!isSocialLink)
                        {
                            links += href + System.Environment.NewLine;
                        }
                    }
                }
            }
            else
            {
                links = string.Empty;
            }
            return links;
        };

        var getImagesData = () =>
        {
            if (document == null)
                return string.Empty;
            string images = string.Empty;
            var imgTags = document.DocumentNode.SelectNodes("//img");
            if (imgTags != null)
            {
                foreach (var img in imgTags)
                {
                    var src = img.Attributes["src"]?.Value ?? "";
                    var alt = img.Attributes["alt"]?.Value ?? "";
                    var width = img.Attributes["width"]?.Value ?? "";
                    var height = img.Attributes["height"]?.Value ?? "";
                    
                    if (!string.IsNullOrEmpty(src))
                    {
                        images += $"{src}";
                        if (!string.IsNullOrEmpty(alt)) images += $" (Alt: {alt})";
                        if (!string.IsNullOrEmpty(width) || !string.IsNullOrEmpty(height)) 
                            images += $" [{width}x{height}]";
                        images += System.Environment.NewLine;
                    }
                }
            }
            return images;
        };

        var getStructureData = () =>
        {
            if (document == null)
                return string.Empty;
            string structure = string.Empty;
            
            // Headers
            for (int i = 1; i <= 6; i++)
            {
                var headers = document.DocumentNode.SelectNodes($"//h{i}");
                if (headers != null && headers.Count > 0)
                {
                    structure += $"H{i} Headers ({headers.Count}):" + System.Environment.NewLine;
                    foreach (var header in headers.Take(5)) // Show only first 5
                    {
                        var text = header.InnerText.Trim();
                        if (!string.IsNullOrEmpty(text))
                            structure += $"  • {text}" + System.Environment.NewLine;
                    }
                    if (headers.Count > 5) structure += $"  ... and {headers.Count - 5} more" + System.Environment.NewLine;
                }
            }
            
            // Paragraphs
            var paragraphs = document.DocumentNode.SelectNodes("//p");
            if (paragraphs != null && paragraphs.Count > 0)
            {
                structure += $"Paragraphs ({paragraphs.Count})" + System.Environment.NewLine;
            }
            
            // Lists
            var lists = document.DocumentNode.SelectNodes("//ul | //ol");
            if (lists != null && lists.Count > 0)
            {
                structure += $"Lists ({lists.Count})" + System.Environment.NewLine;
            }
            
            // Tables
            var tables = document.DocumentNode.SelectNodes("//table");
            if (tables != null && tables.Count > 0)
            {
                structure += $"Tables ({tables.Count})" + System.Environment.NewLine;
            }
            
            return structure;
        };

        var getSocialData = () =>
        {
            if (document == null)
                return string.Empty;
            string social = string.Empty;
            
            // Social media links only (no meta tags)
            var socialLinks = document.DocumentNode.SelectNodes("//a[@href]");
            if (socialLinks != null)
            {
                var socialDomains = new[] { 
                    "facebook.com", "twitter.com", "x.com", "linkedin.com", "instagram.com", 
                    "youtube.com", "tiktok.com", "discord.gg", "discord.com", "github.com",
                    "reddit.com", "pinterest.com", "snapchat.com", "telegram.org", "whatsapp.com",
                    "discord.gg/", "github.com/"
                };
                foreach (var link in socialLinks)
                {
                    var href = link.Attributes["href"]?.Value ?? "";
                    var text = link.InnerText.Trim();
                    if (!string.IsNullOrEmpty(href) && (href.StartsWith("https://") || href.StartsWith("http://")))
                    {
                        foreach (var domain in socialDomains)
                        {
                            if (href.Contains(domain))
                            {
                                social += $"{domain}: {href}";
                                if (!string.IsNullOrEmpty(text)) social += $" ({text})";
                                social += System.Environment.NewLine;
                                break;
                            }
                        }
                    }
                }
            }
            
            return social;
        };

        var eventHandler = (Event<Button> e) =>
        {
            urlTitleState.Set("");
            urlMetaState.Set("");
            urlLinksState.Set("");
            urlImagesState.Set("");
            urlStructureState.Set("");
            urlSocialState.Set("");
            errorState.Set("");
            parsingState.Set(true);
            loadURL(urlState.Value);
            if (document == null)
            {
                parsingState.Set(false);
                errorState.Set("Invalid URL !");
                return;
            }
            urlTitleState.Set(getTitleData());
            urlMetaState.Set(getMetaData());
            urlLinksState.Set(getLinksData());
            urlImagesState.Set(getImagesData());
            urlStructureState.Set(getStructureData());
            urlSocialState.Set(getSocialData());
            parsingState.Set(false);
        };

        // Left side - Form
        var formCard = new Card(
            Layout.Vertical().Gap(3)
                | Text.H3("HtmlAgilityPack Parser")
                | Text.Muted("HTML parser extracts website data: title, images, structure, links, and social media info")
                | urlState.ToSearchInput().WithLabel("Enter Site URL:")
                | dataTypesSelect.ToSelectInput(dataTypeOptions)
                    .Variant(SelectInputs.Toggle)
                    .WithLabel("Select data to extract:")
                | new Button("Parse Site HTML", eventHandler).Loading(parsingState.Value)
                | (errorState.Value.Length > 0 ? Text.Block(errorState.Value) : null)
                | new Spacer().Height(Size.Units(5))
                | Text.Small("This demo uses HtmlAgilityPack library to parse HTML and extract website data.")
                | Text.Markdown("Built with [Ivy Framework](https://github.com/Ivy-Interactive/Ivy-Framework) and [HtmlAgilityPack](https://github.com/zzzprojects/html-agility-pack)")
        );

        // Right side - Results
        var selectedTypes = dataTypesSelect.Value;
        var hasAnyData = (selectedTypes.Contains("title") && urlTitleState.Value.Length > 0) ||
                        (selectedTypes.Contains("meta") && urlMetaState.Value.Length > 0) ||
                        (selectedTypes.Contains("images") && urlImagesState.Value.Length > 0) ||
                        (selectedTypes.Contains("structure") && urlStructureState.Value.Length > 0) ||
                        (selectedTypes.Contains("social") && urlSocialState.Value.Length > 0) ||
                        (selectedTypes.Contains("links") && urlLinksState.Value.Length > 0);
                        
        var resultsContent = !hasAnyData
            ? Layout.Vertical().Gap(2)
                | Text.H3("HTML Parser Results")
                | Text.Muted("Select data types above and click 'Parse Site HTML' to analyze any website")
            : Layout.Vertical().Gap(2)
                | Text.H3("HTML Parser Results")
                | Text.Muted("Select data types above and click 'Parse Site HTML' to analyze any website")
                // Basic information
                | (selectedTypes.Contains("title") && urlTitleState.Value.Length > 0 ? new Expandable(
                    "Site Title",
                    Text.Code(urlTitleState.Value)
                ) : null)
                
                // Meta data
                | (selectedTypes.Contains("meta") && urlMetaState.Value.Length > 0 ? new Expandable(
                    "Site Meta Data",
                    Text.Code(urlMetaState.Value)
                ) : null)
                
                // Images
                | (selectedTypes.Contains("images") && urlImagesState.Value.Length > 0 ? new Expandable(
                    "Images Found",
                    Text.Code(urlImagesState.Value)
                ) : null)
                
                // Page structure
                | (selectedTypes.Contains("structure") && urlStructureState.Value.Length > 0 ? new Expandable(
                    "Page Structure",
                    Text.Code(urlStructureState.Value)
                ) : null)
                
                // Social media
                | (selectedTypes.Contains("social") && urlSocialState.Value.Length > 0 ? new Expandable(
                    "Social Media Links",
                    Text.Code(urlSocialState.Value)
                ) : null)
                
                // External links
                | (selectedTypes.Contains("links") && urlLinksState.Value.Length > 0 ? new Expandable(
                    "External Links",
                    Text.Code(urlLinksState.Value)
                ) : null)
                
                // Error display
                | (errorState.Value.Length > 0 ? new Expandable(
                    "Error",
                    Text.Block(errorState.Value)
                ) : null);

        return Layout.Horizontal(
            formCard,
            new Card(resultsContent).Height(Size.Fit().Min(Size.Full()))
        );
    }
}