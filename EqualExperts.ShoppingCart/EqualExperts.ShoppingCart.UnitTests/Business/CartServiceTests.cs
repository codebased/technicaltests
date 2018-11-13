using EqualExperts.ShoppingCart.Business;
using EqualExperts.ShoppingCart.Repository;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;

namespace EqualExperts.ShoppingCart.UnitTests.Business
{
    [TestFixture]
    public class CartServiceTests
    {
        private CartService sut;
        private IProductRepository productRepository;
        private ITaxService taxService;

        [SetUp]
        public void Setup()
        {
            productRepository = Substitute.For<IProductRepository>();
            taxService = Substitute.For<ITaxService>();

            sut = new CartService(productRepository, taxService);
        }

        [Test]
        public void NewCart_ShouldReturnEmptyTrue()
        {
            // Arrange 

            // Act
            var result = sut.IsEmpty();

            // Assert
            result.ShouldBeTrue();
        }

        [Test]
        public void AddItem_SingleSoap_ShouldReturnEmptyFalse()
        {
            // Arrage
            productRepository.Find(ProductCodes.DoveSoap).Returns(
               new ShoppingCart.Dtos.Product(ProductCodes.DoveSoap, 39.99m)
               );

            sut.Add(ProductCodes.DoveSoap);

            // Act
            var result = sut.IsEmpty();

            // Assert
            result.ShouldBeFalse();
        }

        [Test]
        public void AddItem_NullProducts_ShouldThrowArgumentNullException()
        {
            var result = Should.Throw<ArgumentNullException>(() => sut.Add(null));

            result.ShouldSatisfyAllConditions(
                () => result.Message.ShouldContain("Value cannot be null", Case.Insensitive),
                () => result.ParamName.ShouldBe("productCode")
             );
        }

        [Test]
        public void AddItem_InvalidProduct_ShouldThrowException()
        {
            productRepository.Find("InvalidProductCode").Returns((x) =>
            {
                throw new Exception($"{x[0]} does not exist.");
            });
            var result = Should.Throw<Exception>(() => sut.Add("InvalidProductCode"));

            result.Message.ShouldContain("InvalidProductCode does not exist", Case.Insensitive);
        }

        [Test]
        public void AddItem_RepositoryReturnNullProduct_ShouldThrowExceptionWithInvalidProductMessage()
        {
            productRepository.Find(ProductCodes.DoveSoap).Returns((x) => null);

            var result = Should.Throw<Exception>(() => sut.Add(ProductCodes.DoveSoap));

            result.Message.ShouldContain($"{ProductCodes.DoveSoap} does not exist", Case.Insensitive);
        }


        [Test]
        public void GetTotal_EmptyCart_ShouldReturnZeroTotal()
        {
            var result = sut.GetTotal();

            result.ShouldBe(0.0m);
        }

        [Test]
        public void GetTotal_AddMultipleItemsQuantity_ShouldCalculateTotal()
        {

            // Arrage 
            productRepository.Find(ProductCodes.DoveSoap).Returns(
                new ShoppingCart.Dtos.Product(ProductCodes.DoveSoap, 39.99m)
                );
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            //Act
            var result = sut.GetTotal();

            //Assert
            result.ShouldBe(199.95m);
        }

        [Test]
        public void GetTotal_AddMultipleProducts_MustReturnTwoDecimalsWithRoundUp()
        {
            // Arrage 
            productRepository.Find(ProductCodes.DoveSoap).Returns(
  new ShoppingCart.Dtos.Product(ProductCodes.DoveSoap, 39.99m));

            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            var result = sut.GetTotal();

            result.ShouldBe(199.95m);
        }


        [Test]
        public void GetTotal_AddMultipleProducts_ShouldReturnTwoDecimalWithRoundDown()
        {
            // Arrage 
            productRepository.Find(ProductCodes.DoveSoap).Returns(
                new ShoppingCart.Dtos.Product(ProductCodes.DoveSoap, 6.275m));

            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            var result = sut.GetTotal();

            result.ShouldBe(31.38m);
        }

        [Test]
        public void GetQuantity_AddOneItem_ShouldReturnOneQuatity()
        {
            // Arrage 
            productRepository.Find(ProductCodes.DoveSoap).Returns(
              new Dtos.Product(ProductCodes.DoveSoap, 5.0205m)
              );

            sut.Add(ProductCodes.DoveSoap);

            var result = sut.GetQuantity(ProductCodes.DoveSoap);

            result.ShouldBe(1);
        }

        [Test]
        public void GetQuantity_NoProductInCart_ShouldThrowException()
        {
            // Arrage 
            productRepository.Find(ProductCodes.DoveSoap).Returns(
              new Dtos.Product(ProductCodes.DoveSoap, 5.0205m)
              );

            // Arrage
            var result = Should.Throw<Exception>(() => sut.GetQuantity(ProductCodes.DoveSoap));

            //
            result.Message.ShouldBe($"{ProductCodes.DoveSoap} does not exist in the cart");
        }

        [Test]
        public void GetQuantity_AddItemTwice_ShouldReturnTwoQuantity()
        {

            // Arrage 
            productRepository.Find(ProductCodes.DoveSoap).Returns(
              new Dtos.Product(ProductCodes.DoveSoap, 5.0205m)
              );

            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            //Act
            var result = sut.GetQuantity(ProductCodes.DoveSoap);

            //Assert
            result.ShouldBe(2);
        }

        [Test]
        public void GetQuantity_AddFiveTimes_ThenThreeTimes_ShouldReturnEightQuantity()
        {
            // Arrage 
            productRepository.Find(ProductCodes.DoveSoap).Returns(
               new ShoppingCart.Dtos.Product(ProductCodes.DoveSoap, 39.99m));


            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            //Act
            var result = sut.GetQuantity(ProductCodes.DoveSoap);
            var result2 = sut.GetTotal();
            //Assert
            result.ShouldBe(8);
            result2.ShouldBe(319.92m);
        }


        [Test]
        public void AddProduct_DeoSoap_ShouldContainsRightQuantities()
        {

            // Arrage 
            productRepository.Find(ProductCodes.DoveSoap).Returns(
                new ShoppingCart.Dtos.Product(ProductCodes.DoveSoap, 39.99m));


            productRepository.Find(ProductCodes.AxeDeo).Returns(
              new Dtos.Product(ProductCodes.AxeDeo, 99.99m)
              );

            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            sut.Add(ProductCodes.AxeDeo);
            sut.Add(ProductCodes.AxeDeo);

            var result = sut.GetQuantity(ProductCodes.DoveSoap);
            var result1 = sut.GetQuantity(ProductCodes.AxeDeo);

            result.ShouldBe(2);
            result1.ShouldBe(2);
        }

        [Test]
        public void AddProducts_DeoSoap_ShouldReturnRightTotal()
        {
            // Arrage 
            productRepository.Find(ProductCodes.DoveSoap).Returns(
                new ShoppingCart.Dtos.Product(ProductCodes.DoveSoap, 39.99m));


            productRepository.Find(ProductCodes.AxeDeo).Returns(
              new Dtos.Product(ProductCodes.AxeDeo, 99.99m)
              );

            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            sut.Add(ProductCodes.AxeDeo);
            sut.Add(ProductCodes.AxeDeo);

            var result = sut.GetTotal();

            result.ShouldBe(279.96m);

        }


        [Test]
        [TestCase(99.99, 39.99, 199.98, 79.98)]
        public void GetSubTotal_AddTwoDeo_ShouldReturnRightAmount(decimal deoUnitPrice, decimal soapUnitPrice, decimal expectedDeoSubTotal, decimal expectedSoapSubTotal)
        {

            productRepository.Find(ProductCodes.AxeDeo).Returns(
              new Dtos.Product(ProductCodes.AxeDeo, deoUnitPrice)
              );

            productRepository.Find(ProductCodes.DoveSoap).Returns(
             new Dtos.Product(ProductCodes.DoveSoap, soapUnitPrice)
             );

            sut.Add(ProductCodes.AxeDeo);
            sut.Add(ProductCodes.AxeDeo);

            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            var resultAxeDeoSubTotal = sut.GetProductSubTotal(ProductCodes.AxeDeo);

            var resultDoveSoapSubTotal = sut.GetProductSubTotal(ProductCodes.DoveSoap);

            resultAxeDeoSubTotal.ShouldBe(expectedDeoSubTotal);
            resultDoveSoapSubTotal.ShouldBe(expectedSoapSubTotal);
        }


        [Test]
        public void GetTax_EmptyCart_ShouldReturnZero()
        {
            taxService.CalculateTax(0).Returns(0m);
            sut.GetTotalTax().ShouldBe(0m);
            taxService.Received(1).CalculateTax(0);
        }

        [Test]
        public void GetTax_TwoDeoTwoSoap_ShouldReturnValidTaxTotal()
        {
            productRepository.Find(ProductCodes.AxeDeo).Returns(
             new Dtos.Product(ProductCodes.AxeDeo, 99.99m)
             );

            productRepository.Find(ProductCodes.DoveSoap).Returns(
             new Dtos.Product(ProductCodes.DoveSoap, 39.99m)
             );
            taxService.CalculateTax(279.96m).Returns(35.0m);
            sut.Add(ProductCodes.AxeDeo);
            sut.Add(ProductCodes.AxeDeo);

            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            var result = sut.GetTotalTax();

            result.ShouldBe(35.0m);
            taxService.Received(1).CalculateTax(279.96m);
        }

        [Test]
        public void GetGrossTotal_TwoDeoTwoSoap_ShouldReturnExpectedTotalIncludingTax()
        {
            productRepository.Find(ProductCodes.AxeDeo).Returns(
             new Dtos.Product(ProductCodes.AxeDeo, 99.99m)
             );

            productRepository.Find(ProductCodes.DoveSoap).Returns(
             new Dtos.Product(ProductCodes.DoveSoap, 39.99m)
             );
            taxService.CalculateTax(279.96m).Returns(35.0m);
            sut.Add(ProductCodes.AxeDeo);
            sut.Add(ProductCodes.AxeDeo);

            sut.Add(ProductCodes.DoveSoap);
            sut.Add(ProductCodes.DoveSoap);

            var result = sut.GetGrossTotal();

            result.ShouldBe(314.96m);
            taxService.Received(1).CalculateTax(279.96m);
        }
    }
}