using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LegacyApplication.Tests
{
    [TestClass]
    public class InvoiceTests
    {
        private readonly Invoice _invoice;
        private readonly StoreDataSet _dataSet = new StoreDataSet();
        private readonly List<StoreDataSet.PromotionsRow> _promotions = new List<StoreDataSet.PromotionsRow>();

        public InvoiceTests()
        {
            var promotionsCatalog = A.Fake<IPromotionsCatalog>();
            A.CallTo(() => promotionsCatalog.GetAllPromotions()).Returns(_promotions);
            _invoice = new Invoice(promotionsCatalog);
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

        [TestMethod]
        public void SimplePromotion()
        {
            const int itemPrice = 3;
            const int discount = 1;
            const int minItemsForDiscount = 2;
            const int expectedTotal = itemPrice * minItemsForDiscount - discount;

            var product = CreateProduct(itemPrice);
            DefinePromotion(product, minItemsForDiscount, discount);
            for (int i = 0; i < minItemsForDiscount; i++)
            {
                _invoice.AddProduct(product);
            }

            Assert.AreEqual(expectedTotal, _invoice.CalculateTotal());
        }

        [TestMethod]
        public void ProductAddedIsRaisedForEachPromotion()
        {
            var product1 = CreateProduct(3);
            var product2 = CreateProduct(4);
            var promotion1 = DefinePromotion(product1, 2, 1);
            var promotion2 = DefinePromotion(product2, 1, 0.5m);

            var promotionsReported = new List<StoreDataSet.PromotionsRow>();
            _invoice.PromotionAdded += promotion => promotionsReported.Add(promotion);

            _invoice.AddProduct(product1);
            _invoice.AddProduct(product1);
            _invoice.AddProduct(product2);

            _invoice.CalculateTotal();
            promotionsReported.Should().Equal(promotion1, promotion2);
        }

        private StoreDataSet.PromotionsRow DefinePromotion(StoreDataSet.ProductsRow product, int minQuantity, decimal discount)
        {
            var promotion = _dataSet.Promotions.NewPromotionsRow();
            promotion.ProductsRow = product;
            promotion.Quantity = minQuantity;
            promotion.Discount = discount;
            _promotions.Add(promotion);

            return promotion;
        }

        private StoreDataSet.ProductsRow CreateProduct(decimal price)
        {
            var product = _dataSet.Products.NewProductsRow();
            product.Price = price;
            return product;
        }
    }
}
