using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampaignMonitor.Common.Extensions;

namespace CampaignMonitor.Common.UnitTest
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void TestNullString()
        {
            string value = null;
            Assert.IsTrue(value.IsNullOrEmpty());
        }

        [TestMethod]
        public void TestEmptyString()
        {
            string value = string.Empty;
            Assert.IsTrue(value.IsNullOrEmpty());
        }

        [TestMethod]
        public void TestValueString()
        {
            string value = "a";
            Assert.IsFalse(value.IsNullOrEmpty());

            value = "null";
            Assert.IsFalse(value.IsNullOrEmpty());
        }


    }
}
