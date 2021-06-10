using BAF.Common;
using Binance.Net.Objects.Spot.SpotData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAF.UseCases.Spot.Extensions
{
    public static class SpotExtension
    {
        public static IEnumerable<BinanceBalance> ExcludeCoins(this IEnumerable<BinanceBalance> binanceBalances)
        {
            IList <BinanceBalance> excludedBinanceBalances= new List<BinanceBalance>();
            foreach(var binanceBalance in binanceBalances)
            {
                if (GlobalConst.ExcludeCoins.Contains(binanceBalance.Asset)) continue;
                excludedBinanceBalances.Add(binanceBalance);
            }
            return excludedBinanceBalances;
        }
    }
}
