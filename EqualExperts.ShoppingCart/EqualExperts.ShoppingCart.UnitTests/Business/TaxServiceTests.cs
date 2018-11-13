using EqualExperts.ShoppingCart.Business;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualExperts.ShoppingCart.UnitTests.Business
{
    [TestFixture]
    public class TaxServiceTests
    {
        private TaxService sut;

        [SetUp]
        public void Setup ( )
        {
            sut = new TaxService();
        }
        [Test]
        [TestCase(100.0, 12.50)]
        [TestCase(0, 0)]
        [TestCase(49.9922, 6.25)]
        [TestCase(49.0001, 6.13)]
        [TestCase(279.96, 35.00)]
        public void CalculateTax_WithRound_ShouldReturnExpectedResult(decimal total, decimal expectedResult)
        {
            sut.CalculateTax(total).ShouldBe(expectedResult);
        }
    }
}
