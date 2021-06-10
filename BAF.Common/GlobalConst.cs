using System;
using System.Collections.Generic;

namespace BAF.Common
{
    public static class GlobalConst
    {
        public const string QuoteCurrency = "USDT";

        public static IReadOnlySet<string> ExcludeCoins = new HashSet<string>()
        {
            "USDT"
        };
    }
}
