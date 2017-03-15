using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingService
{
    internal class CoinSensor
    {
        public static decimal GetCoinValue(decimal size, decimal weight)
        {
            if (size == 21.21M && weight == 5M)
                return 0.05M;
            if (size == 17.9M && weight == 2.5M)
                return 0.10M;
            
            if (size == 24.3M && weight == 6.25M)
                return 0.25M;
            throw new InvalidCoinException();
        }
    }
}
