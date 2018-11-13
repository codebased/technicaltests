using EqualExperts.ShoppingCart.Dtos;
using System;

namespace EqualExperts.ShoppingCart.Repository
{

    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _dbContext;

        public ProductRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product Find(string productCode)
        {
            var result = _dbContext.Get(productCode);
            if (result == null)
            {
                throw new Exception($"{productCode} does not exist.");
            }

            return result;
        }
    }
}