using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_crypto_bot_4._0
{
    internal class MarketDataEndpoints
    {
        public static double GetPrice(int symbolID)
        {
            // 6 = BTCUSDT, 7 = ETHUSDT
            string parameters = "https://api-testnet.bybit.com/v2/public/tickers";
            JObject jsonRtn = APIConnections.GET(parameters);

            string lastPrice = jsonRtn["result"][symbolID]["last_price"].ToString();
            return Convert.ToDouble(lastPrice);
        }

        public static Candle[] GetHistoric(string Symbol, int interval, int limit, int period)
        {
            // Symbol eg ETHUSDT, intveral in MINUTES, max = 200 datapoints, Period in days
            string Interval = Convert.ToString(interval);
            string Limit = Convert.ToString(limit);
            int DeltaTime = Convert.ToInt32(DateTimeOffset.Now.ToUnixTimeSeconds()) - period * 60 * 60 * 24;
            string BackTime = Convert.ToString(DeltaTime);

            string parameters = $"https://api-testnet.bybit.com/public/linear/mark-price-kline?symbol={Symbol}&interval={Interval}&limit={Limit}&from={BackTime}";
            JObject jsonRtn = APIConnections.GET(parameters);

            Candle[] candles = new Candle[jsonRtn["result"].Count()];

            int i = 0;
            foreach (var point in jsonRtn["result"])
            {
                candles[i] = new Candle();

                candles[i].close = Convert.ToDouble(point["close"].ToString());
                candles[i].open = Convert.ToDouble(point["open"].ToString());
                candles[i].high = Convert.ToDouble(point["high"].ToString());
                candles[i].low = Convert.ToDouble(point["low"].ToString());
                candles[i].open_time = Convert.ToDouble(point["start_at"].ToString());

                i++;
            }

            return candles;
        }
    }
}
