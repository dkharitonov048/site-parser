using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;

namespace SiteParser.Implementations.Strategies
{
    /// <summary>
    /// Search only the first 10 links and add links to images.
    /// </summary>
    public class ThirdSearchStrategy : SearchStrategy
    {
        public override async Task<Dictionary<string, string>> Search(string url)
        {
            var linkDictionary = new Dictionary<string, string>();

            var document = await GetDocument(url);
            var elements = document.Links.Take(10);
            foreach (var element in elements)
            {
                var href = ((IHtmlAnchorElement)element).Href;
                var title = element.TextContent;

                linkDictionary.TryAdd(href, title);
            }

            var images = document.Images;
            foreach (var image in images)
            {
                linkDictionary.TryAdd(image.Source, image.TagName);
            }

            return linkDictionary;
        }
    }
}