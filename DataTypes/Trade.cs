using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_crypto_bot_4._0
{
    internal class Trade
    {
        public bool type;
        public double entryPrice;
        public double takeprofit;
        public double stoploss;
        public int entryTime;
        public bool isComplete = false;
        public bool won = false;

        // type == TRUE if in long
        // type == FLASE if in short
        public Trade(bool type, double entryPrice, double takeprofit, double stoploss, int entryTime = 0)
        {
            this.type = type;
            this.entryPrice = entryPrice;
            this.takeprofit = takeprofit;
            this.stoploss = stoploss;
            this.entryTime = entryTime;
        }

        public double getLossP()
        {
            if (type) { return stoploss / entryPrice; } // long
            else { return entryPrice / stoploss; }
        }
        public double getProfitP()
        {
            if (type) { return takeprofit / entryPrice; } // long
            else { return entryPrice / takeprofit; }
        }


        public bool hitStoploss(double price)
        {
            if (type)
            {
                if (price <= stoploss) { isComplete = true; return true; } 
                else { return false; }
            }
            else
            {
                if (price >= stoploss) { isComplete = true; return true; } 
                else { return false; }
            }
        }

        public bool hitTakeprofit(double price)
        {
            if (type)
            {
                if (price >= takeprofit) { isComplete = true; won = true; return true; } 
                else { return false; }
            }
            else
            {
                if (price <= takeprofit) { isComplete = true; won = true; return true; } 
                else { return false; }
            }
        }
    }
}
