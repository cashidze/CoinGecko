using System.Threading.Tasks;
using CoinGecko.Clients;
using CoinGecko.Interfaces;
using Xunit;

namespace CoinGecko.Test
{
    public class PingClientTests: TestBase
    {
        private readonly ICoinGeckoClient _client;
        public PingClientTests()
        {
			_client = GetClient();
		}
        [Fact]
        public async Task Ping_Method_Must_Return_ToTheMoon()
        {
            var result = await _client.PingClient.GetPingAsync();
            Assert.Equal("(V3) To the Moon!",result.GeckoSays);
        }
        
    }
}