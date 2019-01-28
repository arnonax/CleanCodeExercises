using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace LegacyApplication
{
	public partial class frmProducts : Form
	{
		public frmProducts()
		{
			InitializeComponent();
		}

		private void frmProducts_Load(object sender, EventArgs e)
		{
			productsTableAdapter.Fill(storeDataSet.Products);
			EnableButtons();
		}

		private void EnableButtons()
		{
			var hasRows = dgvProducts.Rows.Count > 0;
			btnEdit.Enabled = hasRows;
			btnDelete.Enabled = hasRows;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				var frmProduct = new frmProduct();
				var dialogResult = frmProduct.ShowDialog();
				if (dialogResult != DialogResult.OK)
					return;

				productsTableAdapter.Insert(frmProduct.Barcode, frmProduct.Description, frmProduct.Price);
				storeDataSet.Products.AddProductsRow(frmProduct.Barcode, frmProduct.Description, frmProduct.Price);

				dgvProducts.CurrentCell = dgvProducts.Rows.Last().Cells.First();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			var mbr = MessageBox.Show("Are you sure you want to delete the selected product?", "Delete product",
				MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

			if (mbr != DialogResult.Yes)
				return;

			var row = GetCurrentProductRow();
			productsTableAdapter.Delete(row.Id, row.Barcode, row.Description, row.Price);
			row.Delete();
		}

		private StoreDataSet.ProductsRow GetCurrentProductRow()
		{
			Debug.Assert(dgvProducts.CurrentRow != null, "dgvProducts.CurrentRow != null");
			var rowView = dgvProducts.CurrentRow.DataBoundItem as DataRowView;

			Debug.Assert(rowView != null, "rowView != null");
			var row = rowView.Row as StoreDataSet.ProductsRow;

			Debug.Assert(row != null, "row != null");
			return row;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			var row = GetCurrentProductRow();
			var frmProduct = new frmProduct();
			var dialogResult = frmProduct.EditProduct(row);
			if (dialogResult != DialogResult.OK)
				return;

			row.Barcode = frmProduct.Barcode;
			row.Description = frmProduct.Description;
			row.Price = frmProduct.Price;

			try
			{
				productsTableAdapter.Update(row);
				row.AcceptChanges();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Update Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
