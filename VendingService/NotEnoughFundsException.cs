using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VendingService
{
    public class NotEnoughFundsException : Exception, ISerializable
    {
        public decimal ExpectedPrice;

        public NotEnoughFundsException(decimal expectedPrice)
        {
            ExpectedPrice = expectedPrice;
        }
    }
}
