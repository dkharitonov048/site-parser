namespace SiteParser.Interfaces
{
    public interface ISearchStrategyFactory
    {
        ISearchStrategy GetSearchStrategy(string parserName);
    }
}