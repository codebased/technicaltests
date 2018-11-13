using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualExperts.ShoppingCart.Business
{
    public interface ITaxService
    {
        decimal CalculateTax(decimal amount);
    }

    public class TaxService : ITaxService
    {
        private const decimal TAX = .125m;
        public decimal CalculateTax(decimal amount)
        {
            return decimal.Round(amount * TAX, 2);
        }
    }
}
