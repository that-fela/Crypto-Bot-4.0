using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_crypto_bot_4._0.Traders
{
    internal class _BaseTrader
    {
        public bool paperTrading;
        public double fee;
        public Candle[] candles = new Candle[_settings.getMaxSize()];
        public Trade[] trades = new Trade[_settings.getMaxSize()];
        public int i = -1;
        public int ti = -1;
        public double money;
        public double startMoney;
        public int startAfter = 50;

        public _BaseTrader(bool paperTrading = true, double startMoney = 1000, double fee = 0.0015)
        {
            this.paperTrading = paperTrading;
            this.startMoney = startMoney;
            this.money = startMoney;
            this.fee = fee;
        }

        public virtual void ConditionMet()
        {
            
        }

        public void Add(Candle candle)
        {
            i++;
            candles[i] = candle;

            Update();
        }

        public virtual void Update()
        {
            // money shit
            checkPosition();

            // indicator updates here
            updateIndicators();

            // buy/sell logic
            buySellLogic();
        }

        public virtual void checkPosition()
        {

        }

        public virtual void updateIndicators()
        {

        }
        
        public virtual void buySellLogic()
        {

        }

    }
}
