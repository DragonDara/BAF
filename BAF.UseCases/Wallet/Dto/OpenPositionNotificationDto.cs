using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Wallet.Dto
{
    public class OpenPositionNotificationDto: INotification
    {

        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }

        public decimal PriceBuy { get; set; }

        public decimal Profit
        {
            get
            {
                var profit = (CurrentPrice - PriceBuy) / PriceBuy * 100;
                return profit >= 0 ? Convert.ToDecimal(String.Format("{0:0.00}", profit))
                    : -1 * Convert.ToDecimal(String.Format("{0:0.00}", Math.Abs(profit)));
            }
        }
        private char sign;
        public char Sign
        {
            get
            {
                return sign;
            }
            set
            {
                sign = CurrentPrice >= PriceBuy ? '+' : '-';
            }
        }
    }
}
