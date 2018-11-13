using EqualExperts.ShoppingCart.Dtos;
using System.Collections.Generic;

namespace EqualExperts.ShoppingCart.Repository
{
    // In theory anything that has interface is worth to test. However I am going to skip mockdb class because it does not have any logic.
    public class MockDbContext : IDbContext
    {
        private static readonly Dictionary<string, Product> products;

        static MockDbContext()
        {
            products = new Dictionary<string, Product>
            {
                { ProductCodes.DoveSoap, new Product (ProductCodes.DoveSoap, 39.99m )},
                { ProductCodes.AxeDeo, new Product(ProductCodes.AxeDeo, 99.99m )}
            };
        }

        public Product Get(string productCode)
        {
            products.TryGetValue(productCode, out Product product);
            return product;
        }
    }
}