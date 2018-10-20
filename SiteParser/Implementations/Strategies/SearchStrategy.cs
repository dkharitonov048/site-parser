using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using SiteParser.Interfaces;

namespace SiteParser.Implementations.Strategies
{
    public abstract class SearchStrategy : ISearchStrategy
    {
        public abstract Task<Dictionary<string, string>> Search(string url);

        protected virtual async Task<IDocument> GetDocument(string url)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var document = await BrowsingContext.New(config).OpenAsync(url);
            return document;
        }
            
    }
}