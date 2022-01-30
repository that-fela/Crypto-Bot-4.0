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
        private int i = 0;
        public EMA(int length, int size = 200, int smoothing = 2)
        {
            this.length = length;
            this.values = new double[size];
            this.smoothing = smoothing;
        }
        
        public void update(double price)
        {
            if (i > this.length)
            {
                this.values[i] = (price * (this.smoothing / (1 + this.length))) + (this.values.Last() * (1 - (this.smoothing / (1 + this.length))));
            }
            else
            {
                this.values[i] = price;
            }

            i++;
        }

        public double getLast()
        {
            return this.values.Last();
        }
    }
}
