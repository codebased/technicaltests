using EqualExperts.ShoppingCart.Dtos;

namespace EqualExperts.ShoppingCart.Repository
{
    public interface IDbContext
    {
        Product Get(string productCode);
    }
}