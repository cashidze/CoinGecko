using CoinGecko.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace CoinGecko.Clients
{
    public partial class CoinGeckoClient : IDisposable, ICoinGeckoClient
    {
        private static readonly Lazy<CoinGeckoClient> Lazy = new Lazy<CoinGeckoClient>(() => new CoinGeckoClient());

        #region Fields

        private readonly HttpClient _httpClient;
        private bool _isDisposed;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly string _apiKey;
        private readonly bool _isPublicApiForced;

		#endregion Fields

		#region Constructors

		public CoinGeckoClient() : this((JsonSerializerSettings)null)
        {
        }

        public CoinGeckoClient(string apiKey) : this((JsonSerializerSettings)null, apiKey)
        {
        }


        public CoinGeckoClient(HttpClientHandler httpClientHandler) : this(httpClientHandler, serializerSettings: null)
        {
        }

        public CoinGeckoClient(HttpClientHandler httpClientHandler, string apiKey) : this(httpClientHandler, null, apiKey)
        {
            _apiKey = apiKey;
        }

      

        public CoinGeckoClient(JsonSerializerSettings serializerSettings) : this(new HttpClientHandler(), serializerSettings)
        {
        }

        public CoinGeckoClient(JsonSerializerSettings serializerSettings, string apiKey) : this(new HttpClientHandler(), serializerSettings, apiKey)
        {
        }


        public CoinGeckoClient(HttpClientHandler httpClientHandler, JsonSerializerSettings serializerSettings) : this(new HttpClient(httpClientHandler, true), serializerSettings)
        {
        }

        public CoinGeckoClient(HttpClientHandler httpClientHandler, JsonSerializerSettings serializerSettings, string apiKey)
          : this(new HttpClient(httpClientHandler, true), serializerSettings, apiKey)
        {
        }


        public CoinGeckoClient(HttpClient httpClient) : this(httpClient, serializerSettings: null)
        {
        }

        public CoinGeckoClient(HttpClient httpClient, string apiKey) : this(httpClient, null, apiKey)
        {
        }


        public CoinGeckoClient(HttpClient httpClient, JsonSerializerSettings serializerSettings)
        {
            _httpClient = httpClient;
            _serializerSettings = serializerSettings;
        }

        public CoinGeckoClient(HttpClient httpClient, JsonSerializerSettings serializerSettings, string apiKey)
        {
            _httpClient = httpClient;
            _serializerSettings = serializerSettings;
            _apiKey = apiKey;
        }

        public CoinGeckoClient(HttpClient httpClient, JsonSerializerSettings serializerSettings, string apiKey, bool isPublicApiForced)
        {
	        _httpClient = httpClient;
	        _serializerSettings = serializerSettings;
	        _apiKey = apiKey;
	        _isPublicApiForced = isPublicApiForced;

        }

		#endregion Constructors

		#region Properties

		public static CoinGeckoClient Instance => Lazy.Value;

        public ISimpleClient SimpleClient => new SimpleClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IPingClient PingClient => new PingClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public ICoinsClient CoinsClient => new CoinsClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IExchangesClient ExchangesClient => new ExchangesClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IEventsClient EventsClient => new EventsClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IExchangeRatesClient ExchangeRatesClient => new ExchangeRatesClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IGlobalClient GlobalClient => new GlobalClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IContractClient ContractClient => new ContractClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IFinancePlatformsClient FinancePlatformsClient => new FinancePlatformsClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IIndexesClient IndexesClient => new IndexesClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IDerivativesClient DerivativesClient => new DerivativesClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public IStatusUpdatesClient StatusUpdatesClient => new StatusUpdateClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);
        public ISearchClient SearchClient => new SearchClient(_httpClient, _serializerSettings, _apiKey, _isPublicApiForced);

        #endregion Properties

        #region Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            if (disposing)
            {
                _httpClient?.Dispose();
            }
            _isDisposed = true;
        }

        #endregion Methods
    }
}