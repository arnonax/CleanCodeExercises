using System.Windows.Forms;

namespace LegacyApplication
{
	public partial class frmMainMenu : Form
	{
		public frmMainMenu()
		{
			InitializeComponent();
		}

		private void btnProducts_Click(object sender, System.EventArgs e)
		{
			new frmProducts().ShowDialog();
		}

		private void frmMainMenu_Load(object sender, System.EventArgs e)
		{

		}

		private void btnSellingMode_Click(object sender, System.EventArgs e)
		{
		    var dataset = InitializeStoreDataSet();
		    var productsCatalog = new ProductsCatalog(dataset);
		    var promotionsCatalog = new PromotionsCatalog(dataset);
		    new frmSellingMode(productsCatalog, promotionsCatalog).ShowDialog();
		}

	    private static StoreDataSet InitializeStoreDataSet()
	    {
	        var productsTableAdapter = new StoreDataSetTableAdapters.ProductsTableAdapter();
	        productsTableAdapter.ClearBeforeFill = true;
	        var promotionsTableAdapter = new StoreDataSetTableAdapters.PromotionsTableAdapter();
	        promotionsTableAdapter.ClearBeforeFill = true;
	        var dataset = new StoreDataSet();

	        productsTableAdapter.Fill(dataset.Products);
	        promotionsTableAdapter.Fill(dataset.Promotions);
	        return dataset;
	    }

	    private void btnPromotions_Click(object sender, System.EventArgs e)
		{
			new frmPromotions().ShowDialog();
		}
	}
}
