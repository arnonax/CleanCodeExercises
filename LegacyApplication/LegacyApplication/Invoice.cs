namespace LegacyApplication
{
    public class Invoice
    {
        private readonly PromotionsCatalog _promotionsCatalog;

        public Invoice(PromotionsCatalog promotionsCatalog)
        {
            _promotionsCatalog = promotionsCatalog;
        }
    }
}