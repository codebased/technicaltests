using EqualExperts.ShoppingCart.Dtos;
using EqualExperts.ShoppingCart.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EqualExperts.ShoppingCart.Business
{
    public class CartService
    {
        private readonly IProductRepository _productRepository;
        private readonly ITaxService _taxService;
        private readonly Dictionary<Product, ProductOrderDetails> cart;

        public CartService(IProductRepository productRepository, ITaxService taxService)
        {
            _productRepository = productRepository;
            _taxService = taxService;
            cart = new Dictionary<Product, ProductOrderDetails>();
        }

        public void Add(string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                throw new ArgumentNullException(nameof(productCode));
            }

            var product = _productRepository.Find(productCode);

            if (product == null)
            {
                throw new Exception($"{productCode} does not exist.");
            }

            var existingItem = this[product];
            if (existingItem == null)
            {
                this[product] = new ProductOrderDetails { Quantity = 1 };
            }
            else
            {
                existingItem.Quantity++;
            }
        }

        public decimal GetTotal()
        {
            return decimal.Round(cart.Sum((keyValue) => keyValue.Value.Quantity * keyValue.Key.UnitPrice), 2);
        }

        public bool IsEmpty()
        {
            return !cart.Any();
        }

        public int GetQuantity(string productCode)
        {
            var result = GetOrderDetails(productCode);
            return result.Quantity;
        }

        public decimal GetTotalTax()
        {
            return _taxService.CalculateTax(GetTotal());
        }

        private ProductOrderDetails GetOrderDetails(string productCode)
        {
            var product = _productRepository.Find(productCode);

            var result = this[product];

            if (result == null)
            {
                throw new Exception($"{productCode} does not exist in the cart");
            }

            return result;
        }

        private ProductOrderDetails this[Product product]
        {
            set
            {
                cart.Add(product, value);
            }
            get
            {
                cart.TryGetValue(product, out ProductOrderDetails item);
                return item;
            }
        }

        public decimal GetProductSubTotal(string productCode)
        {
            var product = _productRepository.Find(productCode);
            return decimal.Round(cart[product].Quantity * product.UnitPrice, 2);
        }

        public decimal GetGrossTotal()
        {
            return GetTotal() + GetTotalTax();
        }
    }
}