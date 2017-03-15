using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingService;

namespace VendingMachineUi
{
    static class Program
    {
        public static VendingMachine VendingMachine = new VendingMachine();
        static void Main(string[] args)
        {
            while (true)
            {
                var productBought = false;
                while (!productBought)
                {
                    Console.WriteLine("INSERT COIN");
                    Console.WriteLine("Put in a Penny, Nickle, Dime, Or Quarter?");
                    while (InsertCoin()) { }
                    productBought = BuyProduct();
                    if (!productBought)
                    {
                        AskIfWantsChangeBack();
                    }
                    
                }
            }
            
            
        }

        private static void AskIfWantsChangeBack()
        {
            Console.WriteLine("Return your coins? (Y, N)");
            var returnCoins = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (returnCoins == 'Y' || returnCoins == 'y')
                Console.WriteLine($"Your change is ${VendingMachine.DispenseChange()}");
        }

        private static bool BuyProduct()
        {
            Console.WriteLine("Purchase a $1.00 Cola, $0.65 Candy, or $0.50 Chips?");
            Console.WriteLine("Which would you like?");
            var product = Console.ReadLine();
            var change = 0M;
            try
            {
                change = VendingMachine.SelectProduct(product);
            }
            catch (OutOfStockException)
            {
                Console.WriteLine("We do not have this product at this time.");
                return false;
            }
            catch (NotEnoughFundsException exception)
            {
                Console.WriteLine($"PRICE ${exception.ExpectedPrice}");
                return false;
            }
            Console.WriteLine("THANK YOU");
            if(change>0)
                Console.WriteLine($"Please take your change: ${change}");
            return true;
        }

        private static bool InsertCoin()
        {
            Console.WriteLine("What coin will you put in? (P, N, D, Q)");
            var coinName = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Coin coin = new Coin();
            if (coinName == 'N' || coinName == 'n')
                coin = Coins.Nickle;

            if (coinName == 'D' || coinName == 'd')
                coin = Coins.Dime;

            if (coinName == 'Q' || coinName == 'q')
                coin = Coins.Quarter;
            try
            {
                VendingMachine.InsertCoin(coin.Size, coin.Weight);
                Console.WriteLine($"Subtotal:${VendingMachine.Subtotal}");
            }
            catch (InvalidCoinException)
            {
                Console.WriteLine("Invalid coin");
            }
            Console.WriteLine("Put in another coin? (Y, N)");
            var anotherCoin = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return anotherCoin == 'Y' || anotherCoin == 'y';
        }
    }
}
