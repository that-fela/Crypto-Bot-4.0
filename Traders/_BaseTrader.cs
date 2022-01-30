using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_crypto_bot_4._0.Traders
{
    internal class _BaseTrader
    {
        private bool paperTrading;
        private double fee;
        private Candle[] candles = new Candle[_settings.getMaxSize()];
        private int i = 0;

        public double money;
        public double startMoney;

        public _BaseTrader(bool paperTrading = true, double startMoney = 1000, double fee = 0.0015)
        {
            this.paperTrading = paperTrading;
            this.startMoney = startMoney;
            this.money = startMoney;
            this.fee = fee;
        }

        public void Add(Candle candle)
        {
            this.candles[i] = candle;
            i++;

            Update();
        }

        public void Update()
        {

        }
    }
}
