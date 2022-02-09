using System;

namespace cs_crypto_bot_4._0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Testema3ema6ema9();
        }

        static void Testema3ema6ema9()
        {
            Traders.EMA3EMA6EMA9 t = new Traders.EMA3EMA6EMA9(0.04, 0.01);
            Candle[] candles = MarketDataEndpoints.GetHistoric("ETHUSDT", 60, 200, 3);
            Traders.EMA3EMA6EMA9[] traders = new Traders.EMA3EMA6EMA9[1000];

            double[] ret = _SweetSpotFinder.getBestTpSl(
                candles,
                traders,
                new double[] { 0.01, 0.05 }, 
                new double[] { 0.01, 0.05 });

            for (int i = 0; i < ret.Length; i++)
            {
                Console.WriteLine(Convert.ToString(ret[i]));
            }
            Console.WriteLine(Convert.ToString(ret[4] / (ret[4] + ret[5])));

            for (int i = 0; i < candles.Length; i++) { t.Add(candles[i]); }

            Console.WriteLine(Convert.ToString(t.money + "\n"));
            for (int i = 0; i <= t.trades.Length; i++)
            {
                Console.WriteLine(t.trades[i].entryTime);
            }
        }
    }
}
