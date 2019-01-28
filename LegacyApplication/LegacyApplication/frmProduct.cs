using System.Windows.Forms;

namespace LegacyApplication
{
	public partial class frmProduct : Form
	{
		public frmProduct()
		{
			InitializeComponent();
		}

		public string Barcode
		{
			get { return txtBarcode.Text; }
		}

		public string Description
		{
			get { return txtDescription.Text; }
		}

		public decimal Price
		{
			get { return decimal.Parse(mtbPrice.Text); }
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void frmProduct_Load(object sender, System.EventArgs e)
		{
			txtBarcode_TextChanged(null, null);
			txtDescription_TextChanged(null, null);
			mtbPrice_TextChanged(null, null);
		}

		private void txtBarcode_TextChanged(object sender, System.EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtBarcode.Text))
				barcodeErrorProvider.SetError(txtBarcode, "Barcode cannot be empty");
			else
				barcodeErrorProvider.Clear();

			SetOkEnabled();
		}

		private void txtDescription_TextChanged(object sender, System.EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtDescription.Text))
				descriptionErrorProvider.SetError(txtDescription, "Description cannot be empty");
			else
				descriptionErrorProvider.Clear();

			SetOkEnabled();
		}

		private void mtbPrice_TextChanged(object sender, System.EventArgs e)
		{
			decimal price;
			var succeeded = decimal.TryParse(mtbPrice.Text, out price);
			if (!succeeded)
			{
				priceErrorProvider.SetError(mtbPrice, "Price is not a valid decimal amount");
				goto SetOKEnabled;
			}
			if (price <= 0)
			{
				priceErrorProvider.SetError(mtbPrice, "Price must be greater than 0");
				goto SetOKEnabled;
			}

			priceErrorProvider.Clear();
SetOKEnabled:
			SetOkEnabled();
		}

		public void SetOkEnabled()
		{
			btnOK.Enabled =
				string.IsNullOrEmpty(barcodeErrorProvider.GetError(txtBarcode))
				&& string.IsNullOrEmpty(descriptionErrorProvider.GetError(txtDescription))
				&& string.IsNullOrEmpty(priceErrorProvider.GetError(mtbPrice));
		}

		public DialogResult EditProduct(StoreDataSet.ProductsRow productsRow)
		{
			txtBarcode.Text = productsRow.Barcode;
			txtDescription.Text = productsRow.Description;
			mtbPrice.Text = productsRow.Price.ToString(mtbPrice.Mask);
			return ShowDialog();
		}
	}
}
