namespace LegacyApplication
{
    public class PromotionsCatalog : IPromotionsCatalog
    {
        private readonly StoreDataSet _dataset;

        public PromotionsCatalog(StoreDataSet dataset)
        {
            _dataset = dataset;
        }

        public StoreDataSet.PromotionsDataTable GetAllPromotions()
        {
            return _dataset.Promotions;
        }
    }
}