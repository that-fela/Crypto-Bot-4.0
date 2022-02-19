using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_crypto_bot_4._0
{
    public class Candle
    {
        public double high;
        public double low;
        public double open;
        public double close;
        public double volume;
        public int open_time;
        public int close_time;

        public double[] prices = new double[10];

        public int timeFrame;

        public Candle(int timeFrame = 0)
        {
            this.timeFrame = timeFrame;
        }

        public void SetValues(double high, double low, double close, double open, int time = 0)
        {
            this.high = high;
            this.low = low;
            this.close = close;
            this.open = open;
            this.open_time = time;
        }
    }
}
                        