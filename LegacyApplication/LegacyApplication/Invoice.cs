using System.Collections.Generic;

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
    }
}