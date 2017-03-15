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


        public bool SelectProduct(string productName)
        {
            var inventory = new ProductInventory();
            if (!inventory.InStock(productName))
                throw new OutOfStockException();
            var requiredFunds = inventory.ProductPrice(productName);
            if (requiredFunds > Subtotal)
                throw new NotEnoughFundsException(requiredFunds);
            Subtotal = 0;
            return true;
        }

        
    }
}
