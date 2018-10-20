using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using SiteParser.Interfaces;

namespace SiteParser.Implementations
{
    public class Parser
    {
        private readonly ISearchStrategy _strategy;

        public Parser(ISearchStrategy strategy)
        {
            _strategy = strategy;
        }
        public async Task Parse(string url, ConcurrentDictionary<string, string> resultDictionary, string domainName)
        {
            var linkDictionary = await _strategy.Search(url);
            var filteredLinkDictionary = linkDictionary.Where(link=>!resultDictionary.ContainsKey(link.Key)).ToList();

            foreach (var link in filteredLinkDictionary)
            {
                resultDictionary.TryAdd(link.Key, link.Value);
                Console.WriteLine($"{link.Key} --- {link.Value}");
            }

            var tasks = filteredLinkDictionary.Where(item => item.Key.StartsWith(domainName))
                .Select(item => Parse(item.Key, resultDictionary, domainName));

            var runnedTasks = tasks.ToList();

            await Task.WhenAll(runnedTasks);
        }
    }
}