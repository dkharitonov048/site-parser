using System;
using System.Collections.Generic;
using SiteParser.Implementations.Strategies;
using SiteParser.Interfaces;

namespace SiteParser.Implementations
{
    public class SearchStrategyFactory : ISearchStrategyFactory
    {
        private readonly IDictionary<string, ISearchStrategy> _strategies;

        public SearchStrategyFactory()
        {
            _strategies = new Dictionary<string, ISearchStrategy>
            {
                {"First", new FirstSearchStrategy()},
                {"Second", new SecondSearchStrategy()},
                {"Third", new ThirdSearchStrategy()}
            };
        }

        public ISearchStrategy GetSearchStrategy(string parserName)
        {
            if (!_strategies.TryGetValue(parserName, out var parser))
                throw new ArgumentException("Invalid strategy name");
            return parser;
        }
    }
}