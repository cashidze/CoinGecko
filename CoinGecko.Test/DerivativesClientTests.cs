﻿using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using Xunit;

namespace CoinGecko.Test
{
    public class DerivativesClientTests:TestBase
    {
        private readonly ICoinGeckoClient _client;

        public DerivativesClientTests()
        {
	        _client = GetClient();
		}

        [Fact]
        public async Task Derivatives_Count_Not_Equal_Zero()
        {
            var result = await _client.DerivativesClient.GetDerivatives("unexpired");
            Assert.NotEqual(0,result.Count);
        }

        [Fact]
        public async Task Derivatives_Exchanges_Count_Not_Equal_Zero()
        {
            var result = await _client.DerivativesClient.GetDerivativesExchanges();
            Assert.NotEqual(0,result.Count);
        }

        [Fact]
        public async Task Derivatives_Exchanges_By_ID_Name_Must_Equal_to_Bitmex()
        {
            var result = await _client.DerivativesClient.GetDerivativesExchangesById("bitmex");
            Assert.Equal("BitMEX",result.Name);
        }
        
        [Fact]
        public async Task Derivatives_Exchanges_By_ID_Must_Have_Tickers()
        {
            var result = await _client.DerivativesClient.GetDerivativesExchangesById("bitmex", "all");
            Assert.True(result.Tickers.Count > 0);
            Assert.Contains(result.Tickers, t => t.ExpiredAt > 0);
        }

        [Fact]
        public async Task Derivatives_List_Not_Equal_Zero()
        {
            var result = await _client.DerivativesClient.GetDerivativesExchangesList();
            Assert.NotEqual(0,result.Count);
        }
    }
}