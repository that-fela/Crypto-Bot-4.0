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
            Traders.EMA3EMA6EMA9 t = new Traders.EMA3EMA6EMA9(0.04, 0.04);

            Candle[] candles = MarketDataEndpoints.GetHistoric("ETHUSDT", 60, 200, 5);
            for (int i = 0; i < candles.Length; i++) { t.Add(candles[i]); }

            Console.WriteLine(Convert.ToString(t.money));
        }
    }
}
