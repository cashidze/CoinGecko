﻿using System.Threading.Tasks;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using Xunit;

namespace CoinGecko.Test
{
    public class IndexesClientTest: TestBase
    {
        private readonly ICoinGeckoClient _client;
        public IndexesClientTest()
        {
			_client = GetClient();
		}

        [Fact]
        public async Task Indexes_Count_Not_Equal_Zero()
        {
            var result = await _client.IndexesClient.GetIndexes();
            Assert.True(result.Count > 0, "Result GTE 0");
        }

        [Fact]
        public async Task Indexes_List_Count_Not_Equal_Zero()
        {
            var result = await _client.IndexesClient.GetIndexList();
            Assert.True( result.Count > 0,"Result GTE 0");
        }
    }
}