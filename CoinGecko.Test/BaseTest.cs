using CoinGecko.Interfaces;
using System;
using System.Net.Http;
using CoinGecko.Clients;
using Newtonsoft.Json;

namespace CoinGecko.Test
{
	public abstract class TestBase
	{
		/// <summary>
		/// API_KEY used in all requests, for both "Paid" and "Demo" versions
		/// </summary>
		private const string _apiKey = "";
		/// <summary>
		/// Should be set to true if provided key is for "Demo" subscription
		/// </summary>
		private const bool _isPublicApi = true;


		protected ICoinGeckoClient GetClient()
		{
			if (string.IsNullOrEmpty(_apiKey))
			{
				return CoinGeckoClient.Instance;
			}
			else
			{
				return new CoinGeckoClient(new HttpClient(new HttpClientHandler()), new JsonSerializerSettings(), _apiKey, _isPublicApi);
			}
		}

	}
}
