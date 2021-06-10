using System;
using System.Collections.Generic;
using System.Text;

namespace BAF.Entities.Exceptions
{
    public class BalancesNotFoundException: Exception
    {
        public BalancesNotFoundException(): base("You don't have any open positions")
        {

        }
    }
}
