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
            Console.WriteLine("INSERT COIN");
            Console.WriteLine("Put in a Penny, Nickle, Dime, Or Quarter?");
            while (InsertCoin())
            {
                
            }
            
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
