using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LegacyApplication
{
	public partial class frmSellingMode : Form
	{
	    private readonly StoreDataSet _dataset;
		private readonly List<StoreDataSet.ProductsRow> _productsInInvoice = new List<StoreDataSet.ProductsRow>();
	    private readonly ProductsCatalog _productsCatalog;

	    public frmSellingMode(StoreDataSet dataset, ProductsCatalog productsCatalog)
		{
		    _dataset = dataset;
		    _productsCatalog = productsCatalog;
		    InitializeComponent();
		}

		private void txtBarcode_TextChanged(object sender, EventArgs e)
		{
			btnAdd.Enabled = !string.IsNullOrEmpty(txtBarcode.Text);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
		    var barcode = txtBarcode.Text;
		    var product = GetProductByBarcode(barcode);
			if (product == null)
			{
				MessageBox.Show("No product found for the specified barcode", "Selling", MessageBoxButtons.OK,
					MessageBoxIcon.Asterisk);
				return;
			}

			_productsInInvoice.Add(product);
			dgvInvoice.Rows.Add(product.Barcode, product.Description, product.Price);
			txtBarcode.SelectAll();

			var total = _productsInInvoice.Sum(x => x.Price);
			total -= CalculateDiscounts();

			txtTotal.Text = total.ToString("C");
		}

	    private StoreDataSet.ProductsRow GetProductByBarcode(string barcode)
	    {
	        return _productsCatalog.GetProductByBarcode(barcode);
	    }

	    private decimal CalculateDiscounts()
		{
			var totalDisount = 0m;
			dgvPromotions.Rows.Clear();
		    foreach (var promotion in GetAllPromotions())
			{
                var actualQuantity = _productsInInvoice.Count(x => x.Id == promotion.ProductId);
				if (actualQuantity >= promotion.Quantity)
				{
					dgvPromotions.Rows.Add(promotion.Description, promotion.Discount);
					totalDisount += promotion.Discount;
				}
			}
			return totalDisount;
		}

	    private StoreDataSet.PromotionsDataTable GetAllPromotions()
	    {
	        var promotionsCatalog = new PromotionsCatalog(_dataset);
	        return promotionsCatalog.GetAllPromotions();
	    }

	    private void frmSellingMode_Load(object sender, EventArgs e)
		{
			txtTotal.Text = 0m.ToString("C");
		}

		private void btnClearAll_Click(object sender, EventArgs e)
		{
			dgvInvoice.Rows.Clear();
			dgvPromotions.Rows.Clear();
			_productsInInvoice.Clear();
			txtTotal.Text = 0m.ToString("C");
		}
	}
}
