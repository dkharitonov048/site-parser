using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteParser.Interfaces
{
    public interface ISearchStrategy
    {
        Task<Dictionary<string, string>> Search(string url);
    }
}