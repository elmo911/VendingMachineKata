using VendingService;
using Xunit;

namespace VendingMachineUnitTests
{

    public class VendingMachineTests
    {
        [Fact]
        public void InsertCoin_Dime_IncreasesSubtotalBy10Cents()
        {
            //Arrange
            var vendingMachine = new VendingMachine();

            //Act
            var beginingValue = vendingMachine.Subtotal;
            vendingMachine.InsertCoin(17.9M, 2.5M);
            var endingValue = vendingMachine.Subtotal;
            
            //Assert
            Assert.True(endingValue == beginingValue + .10M);
        }

        [Fact]
        public void InsertCoin_Nickle_IncreasesSubtotalBy5Cents()
        {
            //Arrange
            var vendingMachine = new VendingMachine();

            //Act
            var beginingValue = vendingMachine.Subtotal;
            vendingMachine.InsertCoin(21.21M, 5M);
            var endingValue = vendingMachine.Subtotal;

            //Assert
            Assert.True(endingValue == beginingValue + .05M);
        }

        [Fact]
        public void InsertCoin_Quarter_IncreasesSubtotalBy25Cents()
        {
            //Arrange
            var vendingMachine = new VendingMachine();

            //Act
            var beginingValue = vendingMachine.Subtotal;
            vendingMachine.InsertCoin(24.3M, 6.25M);
            var endingValue = vendingMachine.Subtotal;

            //Assert
            Assert.True(endingValue == beginingValue + .25M);
        }
    }
}
