using System;
using System.Data;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegacyApplication.Tests
{
    [TestClass]
    public class InvoiceTests
    {
        private readonly Invoice _invoice;
        private readonly StoreDataSet _dataSet = new StoreDataSet();

        public InvoiceTests()
        {
            _invoice = new Invoice(A.Fake<IPromotionsCatalog>());
        }

        [TestMethod]
        public void InitialTotalIs0()
        {
            var total = _invoice.CalculateTotal();
            Assert.AreEqual(0, total);
        }

        [TestMethod]
        public void TotalOfOneItemIsItsPrice()
        {
            var product = CreateProduct(3);
            _invoice.AddProduct(product);
            Assert.AreEqual(3, _invoice.CalculateTotal());
        }

        [TestMethod]
        public void TotalOfFewItemsIsTheSumOfTheirPrices()
        {
            const int product1Price = 2;
            const int product2Price = 3;
            const int product3Price = 4;
            const int expectedTotal = product1Price + product2Price + product3Price;

            _invoice.AddProduct(CreateProduct(product1Price));
            _invoice.AddProduct(CreateProduct(product2Price));
            _invoice.AddProduct(CreateProduct(product3Price));

            Assert.AreEqual(expectedTotal, _invoice.CalculateTotal());
        }

        private StoreDataSet.ProductsRow CreateProduct(decimal price)
        {
            var product = _dataSet.Products.NewProductsRow();
            product.Price = price;
            return product;
        }
    }
}
