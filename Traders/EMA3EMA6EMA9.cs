using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_crypto_bot_4._0.Traders
{
    internal class EMA3EMA6EMA9 : _BaseTrader
    {
        public double takeprofitP;
        public double stoplossP;

        public Indicators.EMA EMA3 = new Indicators.EMA(3);
        public Indicators.EMA EMA6 = new Indicators.EMA(6);
        public Indicators.EMA EMA9 = new Indicators.EMA(9);

        public EMA3EMA6EMA9(double takeprofitPercentage, double stoplossPercentage, bool paperTrading = true, double startMoney = 1000, double fee = 0.0015)
        {
            this.paperTrading = paperTrading;
            this.startMoney = startMoney;
            this.money = startMoney;
            this.fee = fee;

            this.takeprofitP = takeprofitPercentage;
            this.stoplossP = stoplossPercentage;
        }

        public override void updateIndicators()
        {
            EMA3.update(candles[i].open);
            EMA6.update(candles[i].open);
            EMA9.update(candles[i].open);
        }

        public override void checkPosition()
        {
            if (ti >= 0)
            {
                Trade cur_trade = trades[ti];

                if (cur_trade != null)
                {
                    if (cur_trade.isComplete == false) // if in trade
                    {
                        if (cur_trade.type == true) // long
                        {
                            if (cur_trade.hitStoploss(candles[ti].low)) { money = money * cur_trade.getLossP() - money * fee; }
                            else if (cur_trade.hitTakeprofit(candles[ti].high)) { money = money * cur_trade.getProfitP() - money * fee; }
                        }
                        else if (cur_trade.type == false) // short
                        {
                            if (cur_trade.hitStoploss(candles[ti].high)) { money = money * cur_trade.getLossP() - money * fee; }
                            else if (cur_trade.hitTakeprofit(candles[ti].low)) { money = money * cur_trade.getProfitP() - money * fee; }
                        }
                    }
                }
            }
        }

        public override void buySellLogic()
        {
            if (i > startAfter)
            {
                if ((EMA3.getLast() > EMA6.getLast()) && (EMA6.getLast() > EMA9.getLast()))
                {
                    ti++;
                    // long
                    trades[ti] = new Trade(
                        true,
                        candles[i].close,
                        candles[i].close * (1 + takeprofitP),
                        candles[i].close * (1 - stoplossP));
                }
                else if ((EMA3.getLast() < EMA6.getLast()) && (EMA6.getLast() < EMA9.getLast()))
                {
                    ti++;
                    // short
                    trades[ti] = new Trade(
                        false,
                        candles[i].close,
                        candles[i].close * (1 - takeprofitP),
                        candles[i].close * (1 + stoplossP));

                }
            }
        }
    }
}
