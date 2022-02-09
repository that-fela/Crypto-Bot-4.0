using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_crypto_bot_4._0
{
    internal static class _SweetSpotFinder
    {
        public static double[] getBestTpSl(Candle[] candles, _BaseTrader[] bt, double[] takeprofit, double[] stoploss, double money = 1000, double fee = 0.0015)
        {
            double[] ret = new double[6];
            double[] monies = new double[bt.Length];
            int index = 0;

            for (double i = takeprofit[0]; i < takeprofit[1]; i += 0.01)
            {
                for (double j = stoploss[0]; j < stoploss[1]; j += 0.01)
                {
                    bt[index] = new Traders.EMA3EMA6EMA9(i, j);
                    int candleLength = Convert.ToInt32(candles.Length);
                    for (int k = 0; k <= candleLength - 1; k++) 
                    { 
                        bt[index].Add(candles[k]); 
                    }

                    monies[index] = bt[index].money;

                    index++;
                }
            }

            double maxValue = monies.Max();
            int maxIndex = monies.ToList().IndexOf(maxValue);

            ret[0] = bt[maxIndex].takeprofitP;
            ret[1] = bt[maxIndex].stoplossP;
            ret[2] = monies[maxIndex];
            ret[3] = money;
            ret[4] = bt[maxIndex].wins;
            ret[5] = bt[maxIndex].losses;

            return ret;
        }
    }
}
