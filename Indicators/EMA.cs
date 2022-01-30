using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_crypto_bot_4._0.Indicators
{
    internal class EMA
    {
        public int length;
        public double[] values;

        private int smoothing;
        public int i = -1;
        public EMA(int length, int size = 200, int smoothing = 2)
        {
            this.length = length;
            this.values = new double[size];
            this.smoothing = smoothing;
        }
        
        public void update(double price)
        {
            ++i;

            if (i > length)
            {
                double p1 = (price * ((double)smoothing / (1 + (double)length)));
                double p2 = (values[i - 1] * (1 - ((double)smoothing / (1 + (double)length))));

                values[i] = p1 + p2;
            }
            else
            {
                values[i] = price;
            }
        }

        public double getLast()
        {
            return values[i];
        }
    }
}
