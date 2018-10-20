using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace SiteParser.Implementations.Strategies
{
    /// <summary>
    /// Search all links
    /// </summary>
    public class FirstSearchStrategy : SearchStrategy
    {
        public override async Task<Dictionary<string, string>> Search(string url)
        {
            var linkDictionary = new Dictionary<string, string>();

            var document = await GetDocument(url);
            var elements = document.Links;
            foreach (var element in elements)
            {
                var href = ((IHtmlAnchorElement) element).Href;
                var title = element.TextContent;

                linkDictionary.TryAdd(href, title);
            }

            return linkDictionary;
        }
    }
}