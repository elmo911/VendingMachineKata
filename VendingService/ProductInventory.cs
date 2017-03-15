using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService.Models;

namespace VendingService
{
    internal class ProductInventory
    {
        private static Dictionary<string, VendingProduct> Products;

        public ProductInventory()
        {
            Products= new Dictionary<string, VendingProduct>()
            {
                {"Candy",new VendingProduct()
                {
                    Name = "Candy",
                    Price = .65M
                }},
                {"Chips",new VendingProduct()
                {
                    Name = "Chips",
                    Price = .50M
                }},
                {"Cola",new VendingProduct()
                {
                    Name = "Cola",
                    Price = 1M
                }},
            };
        }

        public bool InStock(string productName)
        {
            return Products.ContainsKey(productName);
        }

        public decimal ProductPrice(string productName)
        {
            return Products[productName].Price;
        }
    }
}
