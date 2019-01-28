using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LegacyApplication
{
	public partial class frmSellingMode : Form
	{
		private readonly StoreDataSet _dataset = new StoreDataSet();
		private readonly List<StoreDataSet.ProductsRow> _productsInInvoice = new List<StoreDataSet.ProductsRow>();

		public frmSellingMode()
		{
			InitializeComponent();
		}

		private void txtBarcode_TextChanged(object sender, EventArgs e)
		{
			btnAdd.Enabled = !string.IsNullOrEmpty(txtBarcode.Text);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			var product = _dataset.Products.FirstOrDefault(p => p.Barcode == txtBarcode.Text);
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

		private decimal CalculateDiscounts()
		{
			var totalDisount = 0m;
			dgvPromotions.Rows.Clear();
			foreach (var promotion in _dataset.Promotions)
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

		private void frmSellingMode_Load(object sender, EventArgs e)
		{
			productsTableAdapter.Fill(_dataset.Products);
			promotionsTableAdapter.Fill(_dataset.Promotions);
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
