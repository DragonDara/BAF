using System;
using System.Collections.Generic;
using System.Text;

namespace BAF.Entities.Exceptions
{
    public class BalanceNotFoundException: Exception
    {
        public BalanceNotFoundException(string symbol): base($"You don't have {symbol} in your balance")
        {

        }
    }
}
