using Bybit.Net.Clients;
using Bybit.Net.Interfaces.Clients;
using Bybit.Net.Objects.Models.Spot.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Code
{
    public class BybitExchangeRate : IExchangeRate
    {
        private readonly IBybitClient _client;

        public BybitExchangeRate()
        {
            _client = new BybitClient();
        }

        public async Task<decimal> GetBTCUSDT()
        {
            var tickerData = await _client.SpotApiV3.ExchangeData.GetTickersAsync();

            var btcusdt = tickerData.Data.FirstOrDefault(x => x.Symbol == "BTCUSDT");

            if(btcusdt == null)
            {
                return 0;
            }

            return btcusdt.LastPrice;
        }
    }
}
