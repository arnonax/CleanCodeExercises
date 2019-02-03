using System;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegacyApplication.Tests
{
    [TestClass]
    public class InvoiceTests
    {
        [TestMethod]
        public void InitialTotalIs0()
        {
            var invoice = new Invoice(A.Fake<IPromotionsCatalog>());
            var total = invoice.CalculateTotal();
            Assert.AreEqual(0, total);
        }
    }
}
