using System;
using System.Collections.Generic;
using System.Linq;

namespace LegacyApplication
{
    public class Invoice
    {
        private readonly IPromotionsCatalog _promotionsCatalog;
        private readonly List<StoreDataSet.ProductsRow> _productsInInvoice = new List<StoreDataSet.ProductsRow>();

        public event Action<StoreDataSet.PromotionsRow> PromotionAdded;

        public Invoice(IPromotionsCatalog promotionsCatalog)
        {
            _promotionsCatalog = promotionsCatalog;
        }

        public void AddProduct(StoreDataSet.ProductsRow product)
        {
            _productsInInvoice.Add(product);
        }

        public decimal CalculateTotal()
        {
            var total = _productsInInvoice.Sum(x => x.Price);
            total -= CalculateDiscounts();
            return total;
        }

        private decimal CalculateDiscounts()
        {
            var totalDisount = 0m;
            foreach (var promotion in _promotionsCatalog.GetAllPromotions())
            {
                var actualQuantity = _productsInInvoice.Count(x => x.Id == promotion.ProductId);
                if (actualQuantity >= promotion.Quantity)
                {
                    RaisePromotionAdded(promotion);
                    totalDisount += promotion.Discount;
                }
            }
            return totalDisount;
        }

        private void RaisePromotionAdded(StoreDataSet.PromotionsRow promotion)
        {
            PromotionAdded?.Invoke(promotion);
        }
    }
}