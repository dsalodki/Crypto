using Binance.Net.Clients;
using Binance.Net.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Code
{
    public class BinanceExchangeRate : IExchangeRate
    {
        private readonly IBinanceClient _client;

        public BinanceExchangeRate()
        {
            _client = new BinanceClient();
        }

        public async Task<decimal> GetBTCUSDT()
        {
            // Getting ticker
            var coinFuturesTickerData = await _client.CoinFuturesApi.ExchangeData.GetTickersAsync();

            var btcusdt = coinFuturesTickerData.Data.FirstOrDefault(x => ((Binance.Net.Objects.Models.Futures.BinanceFuturesCoin24HPrice)x).Pair == "BTCUSD");

            if(btcusdt == null)
            {
                return 0;
            }

            return btcusdt.LastPrice;
        }
    }
}
