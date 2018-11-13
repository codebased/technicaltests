using EqualExperts.ShoppingCart.Dtos;

namespace EqualExperts.ShoppingCart.Repository
{
    public interface IProductRepository
    {
        Product Find(string productCode);
    }
}