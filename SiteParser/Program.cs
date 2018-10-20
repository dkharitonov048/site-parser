using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using SiteParser.Implementations;
using SiteParser.Interfaces;

namespace SiteParser
{
    class Program
    {
        private static readonly ISearchStrategyFactory Factory;
        static Program()
        {
            Factory = new SearchStrategyFactory();
        }
        static async Task Main(string[] args)
        {
            var address = "https://mail.ru/";
            var uri = new Uri(address);
            var domain = $"{uri.Scheme}://{uri.Host}";

            var strategy = Factory.GetSearchStrategy("First");
            //var strategy = _factory.GetSearchStrategy("Second");
            //var strategy = _factory.GetSearchStrategy("Third");

            var parser = new Parser(strategy);

            var returnedLinks = new ConcurrentDictionary<string, string>();

            Console.WriteLine("Search started");
            await parser.Parse(address, returnedLinks, domain);

            foreach (var link in returnedLinks.OrderBy(it => it.Key))
            {
                Console.WriteLine($"{link.Key} --- {link.Value}");
            }

            Console.WriteLine("Search finished");


        }


    }
}
