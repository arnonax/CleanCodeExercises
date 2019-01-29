using System.Linq;

namespace LegacyApplication
{
    public class ProductsCatalog
    {
        private readonly StoreDataSet _dataset;

        public ProductsCatalog(StoreDataSet dataset)
        {
            _dataset = dataset;
        }

        public StoreDataSet.ProductsRow GetProductByBarcode(string barcode)
        {
            return _dataset.Products.FirstOrDefault(p => p.Barcode == barcode);
        }
    }
}
