using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;

namespace SiteParser.Implementations.Strategies
{
    /// <summary>
    /// Search on pages with size > 200Kb and exclude "mailto:" links
    /// </summary>
    public class SecondSearchStrategy : SearchStrategy
    {
        private const int PageSizeKb = 200;
        public override async Task<Dictionary<string, string>> Search(string url)
        {
            var linkDictionary = new Dictionary<string, string>();

            var document = await GetDocument(url);
            if (document != null)
            {
                var elements = document.Links;
                foreach (var element in elements)
                {
                    var href = ((IHtmlAnchorElement) element).Href;
                    var title = element.TextContent.Trim();
                    if (!href.Contains("mailto:"))
                        linkDictionary.TryAdd(href, title);
                }
            }

            return linkDictionary;
        }

        protected override async Task<IDocument> GetDocument(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var urlContent = await response.Content.ReadAsByteArrayAsync();
                var length = urlContent.Length;
                if (length / 1024f < PageSizeKb)
                    return null;
                var stringContent = await response.Content.ReadAsStringAsync();
                var parser = new HtmlParser();
                var document = parser.Parse(stringContent);
                return document;
            }
        }
    }
}