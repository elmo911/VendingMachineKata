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

        [Fact]
        public void SelectProduct_Candy_DispenseCandy()
        {
            //Arrange
            var vendingMachine = new VendingMachine();
            var quarter = Coins.Quarter;
            var dime = Coins.Dime;
            var nickle = Coins.Nickle;

            //Act
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(dime.Size, dime.Weight);
            vendingMachine.InsertCoin(nickle.Size, nickle.Weight);
            var recievedProduct = vendingMachine.SelectProduct("Candy");

            //Assert
            Assert.True(recievedProduct);
        }

        [Fact]
        public void SelectProduct_Chips_DispenseChips()
        {
            //Arrange
            var vendingMachine = new VendingMachine();
            var quarter = Coins.Quarter;

            //Act
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            var recievedProduct = vendingMachine.SelectProduct("Chips");

            //Assert
            Assert.True(recievedProduct);
        }

        [Fact]
        public void SelectProduct_Cola_DispenseCola()
        {
            //Arrange
            var vendingMachine = new VendingMachine();
            var quarter = Coins.Quarter;

            //Act
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            var recievedProduct = vendingMachine.SelectProduct("Cola");

            //Assert
            Assert.True(recievedProduct);
        }

        [Fact]
        public void SelectProduct_BoughtProduct_SubtotalIs0()
        {
            //Arrange
            var vendingMachine = new VendingMachine();
            var quarter = Coins.Quarter;

            //Act
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            var recievedProduct = vendingMachine.SelectProduct("Cola");

            //Assert
            Assert.True(vendingMachine.Subtotal == 0);
        }

        [Fact]
        public void SelectProduct_NoMoney_ThrowsNotEnoughFunds()
        {
            //Arrange
            var vendingMachine = new VendingMachine();

            //Act
            //Assert
            Assert.Throws<NotEnoughFundsException>(() => vendingMachine.SelectProduct("Candy"));
        }

        [Fact]
        public void SelectProduct_TooMuchMoney_DispenseCandy()
        {
            //Arrange
            var vendingMachine = new VendingMachine();
            var quarter = Coins.Quarter;

            //Act
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            vendingMachine.InsertCoin(quarter.Size, quarter.Weight);
            var recievedProduct = vendingMachine.SelectProduct("Candy");

            //Assert
            Assert.True(recievedProduct);
        }

        [Fact]
        public void SelectProduct_InvalidProduct_ThrowsOutOfStock()
        {
            //Arrange
            var vendingMachine = new VendingMachine();

            //Act
            //Assert
            Assert.Throws<OutOfStockException>(() => vendingMachine.SelectProduct("Fake Candy"));
        }
    }
}
