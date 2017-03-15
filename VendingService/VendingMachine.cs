using System;

namespace VendingService
{
    public class VendingMachine
    {
        public decimal Subtotal { get; private set; }

        public void InsertCoin(decimal size, decimal weight)
        {
            Subtotal += CoinSensor.GetCoinValue(size, weight);
        }

        
    }
}
