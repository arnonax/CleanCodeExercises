using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace LegacyApplication
{
	public partial class frmPromotion : Form
	{
		private int? _initialProductId;

		public frmPromotion()
		{
			InitializeComponent();
		}

		public string Descrpition { get { return txtDescription.Text; } }
		public int ProductId {
			get
			{
				return GetSelectedProduct().Id;
			}
		}

		public int Quantity
		{
			get { return (int) nudQuantity.Value; }
		}

		public decimal Discount
		{
			get { return decimal.Parse(mtbDiscount.Text); }
		}

		public DialogResult EditPromotion(StoreDataSet.PromotionsRow row)
		{
			txtDescription.Text = row.Description;
			_initialProductId = row.ProductId;
			nudQuantity.Value = row.Quantity;
			mtbDiscount.Text = row.Discount.ToString(mtbDiscount.Mask);

			return ShowDialog();
		}

		private void txtDescription_TextChanged(object sender, EventArgs e)
		{
			ValidateControls();
		}

		private void SetOkEnabled()
		{
			var validatableControls = new Control[]
			{
				txtDescription,
				cboProduct,
				nudQuantity,
				mtbDiscount
			};

			btnOK.Enabled = validatableControls.None(HasError);
		}

		private void frmPromotion_Load(object sender, EventArgs e)
		{
			productsTableAdapter.Fill(storeDataSet.Products);
			UpdateProductDetails();
			ValidateControls();
		}

		private void ValidateControls()
		{
			ValidateDescription();
			ValidateProduct();
			ValidatePositiveDiscount();
			ValidateDiscount();

			SetOkEnabled();
		}

		private void ValidateDescription()
		{
			string errorMessage = null;
			if (string.IsNullOrWhiteSpace(txtDescription.Text))
				errorMessage = "Description must not be empty";

			errorProvider.SetError(txtDescription, errorMessage);
		}

		private void cboProduct_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateProductDetails();

			ValidateControls();
		}

		private void UpdateProductDetails()
		{
			if (_initialProductId != null)
			{
				cboProduct.SelectedItem =
					cboProduct.Items.Cast<DataRowView>()
						.SingleOrDefault(x => ((StoreDataSet.ProductsRow) x.Row).Id == _initialProductId.Value);
				_initialProductId = null;
			}

			var product = GetSelectedProduct();
			txtBarcode.Text = product.Barcode;
			txtProductPrice.Text = product.Price.ToString("C");
		}

		private void ValidateProduct()
		{
			string errorMessage = null;

			if (cboProduct.SelectedItem == null)
				errorMessage = "Please select a product";

			errorProvider.SetError(cboProduct, errorMessage);
		}

		private void ValidateDiscount()
		{
			string errorMessage = null;
			if (HasError(mtbDiscount))
				return;

			if (HasError(cboProduct))
				return;
			
			var product = GetSelectedProduct();
			if (Discount > product.Price*Quantity)
				errorMessage = "Discount cannot be greater than the product's price * quantity";

			errorProvider.SetError(mtbDiscount, errorMessage);
		}

		private StoreDataSet.ProductsRow GetSelectedProduct()
		{
			var dataRowView = cboProduct.SelectedItem as DataRowView;
			Debug.Assert(dataRowView != null, "dataRowView != null");
			var product = dataRowView.Row as StoreDataSet.ProductsRow;
			Debug.Assert(product != null, "product != null");
			return product;
		}

		private bool HasError(Control control)
		{
			return !string.IsNullOrEmpty(errorProvider.GetError(control));
		}

		private void nudQuantity_ValueChanged(object sender, EventArgs e)
		{
			ValidateControls();
		}

		private void mtbDiscount_TextChanged(object sender, EventArgs e)
		{
			ValidateControls();
		}

		private void ValidatePositiveDiscount()
		{
			string errorMessage = null;
			decimal discount;
			var succeeded = decimal.TryParse(mtbDiscount.Text, out discount);
			if (!succeeded)
			{
				errorMessage = "Discount is not a valid decimal amount";
				goto setError;
			}
			if (discount <= 0)
				errorMessage = "Discount must be greater than 0";

			setError:

			errorProvider.SetError(mtbDiscount, errorMessage);
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
