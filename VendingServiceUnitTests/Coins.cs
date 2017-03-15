using VendingMachineUi;

namespace VendingMachineUnitTests
{
    internal class Coins
    {
        public static Coin Nickle => new Coin()
        {
            Weight = 5M,
            Size = 21.21M
        };

        public static Coin Dime => new Coin()
        {
            Weight = 2.5M,
            Size = 17.9M
        };

        public static Coin Quarter => new Coin()
        {
            Weight = 6.25M,
            Size = 24.3M
        };
    }
}
