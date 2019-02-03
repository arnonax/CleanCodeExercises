using System;
using System.Windows.Forms;

namespace LegacyApplication
{
	public partial class frmSellingMode : Form
	{
	    private readonly ProductsCatalog _productsCatalog;
	    private readonly IPromotionsCatalog _promotionsCatalog;

	    private Invoice _invoice;

	    public frmSellingMode(ProductsCatalog productsCatalog, IPromotionsCatalog promotionsCatalog)
		{
		    _productsCatalog = productsCatalog;
		    _promotionsCatalog = promotionsCatalog;
		    _invoice = CreateNewInvoice();
		    InitializeComponent();
		}

	    private Invoice CreateNewInvoice()
	    {
	        var invoice = new Invoice(_promotionsCatalog);
	        invoice.PromotionAdded += PromotionAdded;
	        return invoice;
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

		    _invoice.AddProduct(product);
		    dgvInvoice.Rows.Add(product.Barcode, product.Description, product.Price);
			txtBarcode.SelectAll();

		    dgvPromotions.Rows.Clear();
		    var total = _invoice.CalculateTotal();

		    txtTotal.Text = total.ToString("C");
		}

	    private StoreDataSet.ProductsRow GetProductByBarcode(string barcode)
	    {
	        return _productsCatalog.GetProductByBarcode(barcode);
	    }

	    private void PromotionAdded(StoreDataSet.PromotionsRow promotion)
	    {
	        dgvPromotions.Rows.Add(promotion.Description, promotion.Discount);
	    }

	    private void frmSellingMode_Load(object sender, EventArgs e)
		{
			txtTotal.Text = 0m.ToString("C");
		}

		private void btnClearAll_Click(object sender, EventArgs e)
		{
			dgvInvoice.Rows.Clear();
			dgvPromotions.Rows.Clear();
		    _invoice = CreateNewInvoice();
			txtTotal.Text = 0m.ToString("C");
		}
	}
}
