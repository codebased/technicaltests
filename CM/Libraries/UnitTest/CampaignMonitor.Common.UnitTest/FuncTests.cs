using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampaignMonitor.Common.Extensions;
using System.Collections.Generic;

namespace CampaignMonitor.Common.UnitTest
{
    [TestClass]
    public class FuncTests
    {
        [TestMethod]
        public void TestFactorSixty()
        {
            List<int> result = Func.Factor(60);
            int[] expectedResult = { 1, 2, 3, 4, 5, 6, 10, 12, 15, 20, 30, 60 };
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TestFactorFourtyTwo()
        {
            List<int> result = Func.Factor(42);
            int[] expectedResult = { 1, 2, 3, 6, 7, 14, 21, 42 };
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
    "Only positive whole integer number is allowed.")]
        public void TestFactorNegativeValue()
        {
            List<int> result = Func.Factor(-243);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTriangleException))]
        public void TestInvalidTriangleArea()
        {

            int a = 1;
            int b = 2;
            int c = 0;
            Func.TriangleArea(a, b, c);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTriangleException))]
        public void TestInvalidNegativeTriangleArea()
        {

            int a = -11;
            int b = 2;
            int c = 5;
            Func.TriangleArea(a, b, c);
        }

        [TestMethod]
        public void TestTriangleArea()
        {
            int a = 3;
            int b = 4;
            int c = 5;
            Func.TriangleArea(a, b, c);
        }

        [TestMethod]
        public void TestCommonValue()
        {

            List<int> value = new List<int>(new[] {5, 4, 3, 2, 4, 5, 1, 6, 1, 2, 5, 4 });
            value = Func.MostCommonIntegers(value);
            int[] expectedResult = { 5, 4};
            CollectionAssert.AreEqual(expectedResult, value);

        }

        [TestMethod]
        public void TestCommonValue1()
        {

            List<int> value = new List<int>(new[] { 1, 2, 3, 4, 5, 1, 6, 7 });
            value = Func.MostCommonIntegers(value);
            int[] expectedResult = { 1 };
            CollectionAssert.AreEqual(expectedResult, value);

        }

        [TestMethod]
        public void TestCommonValue2()
        {
            List<int> value = new List<int>(new[] { 1, 2, 3, 4, 5, 6, 7 });
            value = Func.MostCommonIntegers(value);
            int[] expectedResult = { 1, 2, 3, 4, 5, 6, 7 };
            CollectionAssert.AreEqual(expectedResult, value);

        }


        [TestMethod]
        public void TestMaxNumbers()
        {
            List<int> value = new List<int>(new[] { 2,173,374,372,11,1 });
            value = Func.MaxNumbers(value, 2);
            int[] expectedResult = { 2,3 };
            CollectionAssert.AreEqual(expectedResult, value);

        }
    }
}