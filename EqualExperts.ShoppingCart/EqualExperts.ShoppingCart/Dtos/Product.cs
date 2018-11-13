namespace EqualExperts.ShoppingCart.Dtos
{
    public class Product
    {
        public decimal UnitPrice { get; set; }
        public string Name { get; set; }

        public Product(string name, decimal unitPrice)
        {
            Name = name;
            UnitPrice = unitPrice;
        }
    }
}
