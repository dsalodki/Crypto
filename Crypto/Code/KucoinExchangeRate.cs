using Kucoin.Net.Clients;
using Kucoin.Net.Interfaces.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto.Code
{
    public class KucoinExchangeRate : IExchangeRate
    {
        private readonly IKucoinClient _client;
        public KucoinExchangeRate()
        {
            _client = new KucoinClient();
        }

        public async Task<decimal> GetBTCUSDT()
        {
            var ticketData = await _client.SpotApi.ExchangeData.GetTickersAsync();

            var btcusdt = ticketData.Data.Data.FirstOrDefault(x => x.SymbolName == "BTC-USDT");

            if(btcusdt == null)
            {
                return 0;
            }

            return btcusdt.LastPrice.HasValue ? btcusdt.LastPrice.Value : 0;
        }
    }
}
