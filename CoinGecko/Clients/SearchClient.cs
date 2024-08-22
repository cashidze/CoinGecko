using CoinGecko.ApiEndPoints;
using CoinGecko.Entities.Response.Search;
using CoinGecko.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinGecko.Clients
{
    public class SearchClient : BaseApiClient, ISearchClient
    {
        public SearchClient(HttpClient httpClient, JsonSerializerSettings jsonSerializerSetting) : base(httpClient, jsonSerializerSetting)
        {
        }

        public SearchClient(HttpClient httpClient, JsonSerializerSettings jsonSerializerSetting, string apiKey) : base(httpClient, jsonSerializerSetting, apiKey)
        {
        }

        public SearchClient(HttpClient httpClient, JsonSerializerSettings serializerSettings, string apiKey, bool isPublicApiForced) : base(httpClient,
	        serializerSettings, apiKey, isPublicApiForced)
        {
        }

		public async Task<TrendingList> GetSearchTrending()
        {
            return await GetAsync<TrendingList>(
                 AppendQueryString(SearchApiEndpoints.SearchTrending))
                .ConfigureAwait(false);
        }
    }
}