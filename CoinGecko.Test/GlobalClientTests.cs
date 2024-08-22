using System.Threading.Tasks;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using Xunit;

namespace CoinGecko.Test
{
    public class GlobalClientTests: TestBase
    {
        private readonly ICoinGeckoClient _client;

        public GlobalClientTests()
        {
	        _client = GetClient();
		}

        [Fact]
        public async Task Global_Data_Must_Not_Null()
        {
            var result = await _client.GlobalClient.GetGlobal();
            Assert.NotNull(result.Data);
        }

        [Fact]
        public async Task Global_DeFi_Data_Type_Must_Equal()
        {
            var result = await _client.GlobalClient.GetGlobalDeFi();
            Assert.IsType<decimal>(result.Data.DeFiMarketCap);
        }
    }
}