using System.Linq;
using System.Threading.Tasks;
using CoinGecko.Interfaces;
using Xunit;

namespace CoinGecko.Test
{
    public class StatusUpdatesClientTest: TestBase
    {
        private readonly ICoinGeckoClient _client;
        
        public StatusUpdatesClientTest()
        {
	        _client = GetClient();
		}

        [Theory]
        [InlineData("general")]
        [InlineData("milestone")]
        public async Task Return_Category_Count_Must_be_Equal_to_All_count(string category)
        {
            
                var result = await _client.StatusUpdatesClient.GetStatusUpdate(category, "", 100, 1);
                var returnProjectCount = result.StatusUpdates.Count(x => x.Category == category);
                var returnCount = result.StatusUpdates.Length;
                Assert.Equal(returnCount,returnProjectCount);
        }
        
        [Theory]
        [InlineData("Market")]
        [InlineData("Coin")]
        public async Task Return_Project_Type_Count_Must_be_Equal_to_All_count(string projectType)
        {
            var result = await _client.StatusUpdatesClient.GetStatusUpdate("", projectType, 100, 1);
            var returnProjectCount = result.StatusUpdates.Count(x => x.Project.Type == projectType);
            var returnCount = result.StatusUpdates.Length;
            Assert.Equal(returnCount,returnProjectCount);
        }
    }
}