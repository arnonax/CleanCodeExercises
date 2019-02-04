using System.Collections.Generic;

namespace LegacyApplication
{
    public class PromotionsCatalog : IPromotionsCatalog
    {
        private readonly StoreDataSet _dataset;

        public PromotionsCatalog(StoreDataSet dataset)
        {
            _dataset = dataset;
        }

        public IEnumerable<StoreDataSet.PromotionsRow> GetAllPromotions()
        {
            return _dataset.Promotions;
        }
    }
}