﻿using System.Threading.Tasks;
using CoinGecko.Interfaces;
using CoinGecko.Clients;
using Xunit;

namespace CoinGecko.Test
{
    public class SearchClientTests: TestBase
    {
        private readonly ICoinGeckoClient _client;

        public SearchClientTests()
        {
			_client = GetClient();
		}

        [Fact]
        public async Task SearchTrending_TrendingItems_Fields_Not_Null()
        {
            var result = (await _client.SearchClient.GetSearchTrending()).TrendingItems[0].TrendingItem;
            Assert.NotNull(result.Id);
        }
    }
}
