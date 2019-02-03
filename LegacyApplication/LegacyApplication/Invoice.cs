using System;
using System.Collections.Generic;
using System.Linq;

namespace LegacyApplication
{
    public class Invoice
    {
        private readonly PromotionsCatalog _promotionsCatalog;
        // TODO: change to private after moving all references to it into this class.
        public readonly List<StoreDataSet.ProductsRow> _productsInInvoice = new List<StoreDataSet.ProductsRow>();

        public Invoice(PromotionsCatalog promotionsCatalog)
        {
            _promotionsCatalog = promotionsCatalog;
        }

        public void AddProduct(StoreDataSet.ProductsRow product)
        {
            _productsInInvoice.Add(product);
        }

        public decimal CalculateTotal(Action<StoreDataSet.PromotionsRow> promotionAdded)
        {
            var total = _productsInInvoice.Sum(x => x.Price);
            total -= CalculateDiscounts(promotionAdded);
            return total;
        }

        private decimal CalculateDiscounts(Action<StoreDataSet.PromotionsRow> promotionAdded)
        {
            var totalDisount = 0m;
            foreach (var promotion in _promotionsCatalog.GetAllPromotions())
            {
                var actualQuantity = _productsInInvoice.Count(x => x.Id == promotion.ProductId);
                if (actualQuantity >= promotion.Quantity)
                {
                    promotionAdded(promotion);
                    totalDisount += promotion.Discount;
                }
            }
            return totalDisount;
        }
    }
}