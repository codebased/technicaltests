using EqualExperts.ShoppingCart.Dtos;
using EqualExperts.ShoppingCart.Repository;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;

namespace EqualExperts.ShoppingCart.UnitTests.Repository
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private readonly IDbContext _dbContext;
        private readonly ProductRepository sut;

        public ProductRepositoryTests()
        {
            _dbContext = Substitute.For<IDbContext>();
            sut = new ProductRepository(_dbContext);
        }

        [Test]
        public void GetProduct_NullResult_ShouldThrowException()
        {
            _dbContext.Get(ProductCodes.DoveSoap).Returns(x => null);

            var result = Should.Throw<Exception>(() => sut.Find(ProductCodes.DoveSoap));

            result.Message.ShouldContain($"{ProductCodes.DoveSoap} does not exist");
            _dbContext.Received().Get(ProductCodes.DoveSoap);
        }

        [Test]
        public void GetProduct_SuccessProduct_ShouldReturnProduct()
        {
            var mockProduct = new Product(ProductCodes.DoveSoap, 19.0m);
            _dbContext.Get(ProductCodes.DoveSoap).Returns(x => mockProduct);

            var result = sut.Find(ProductCodes.DoveSoap);

            result.ShouldBe(mockProduct);
            _dbContext.Received().Get(ProductCodes.DoveSoap);

        }

        [Test]
        public void GetProduct_AxeDeo_ShouldExists()
        {
            var mockProduct = new Product(ProductCodes.AxeDeo, 99.99m);
            _dbContext.Get(ProductCodes.AxeDeo).Returns(x => mockProduct);

            var result = sut.Find(ProductCodes.AxeDeo);

            result.ShouldBe(mockProduct);
            _dbContext.Received().Get(ProductCodes.AxeDeo);

        }

    }
}
