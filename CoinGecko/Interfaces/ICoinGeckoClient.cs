namespace CoinGecko.Interfaces
{
    public interface ICoinGeckoClient
    {
        ICoinsClient CoinsClient { get; }
    }
}