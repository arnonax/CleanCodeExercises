using System.Collections;
using System.Collections.Generic;

namespace LegacyApplication
{
    public interface IPromotionsCatalog
    {
        IEnumerable<StoreDataSet.PromotionsRow> GetAllPromotions();
    }
}