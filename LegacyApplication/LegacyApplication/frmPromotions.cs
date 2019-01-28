using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace LegacyApplication
{
	public partial class frmPromotions : Form
	{
		public frmPromotions()
		{
			InitializeComponent();
		}

		private void frmPromotions_Load(object sender, EventArgs e)
		{
			promotionsWithProductDetailsTableAdapter.Fill(storeDataSet.PromotionsWithProductDetails);
			promotionsTableAdapter.Fill(storeDataSet.Promotions);
			EnableButtons();
		}

		private void EnableButtons()
		{
			var hasRows = dataGridView.Rows.Count > 0;
			btnEdit.Enabled = hasRows;
			btnDelete.Enabled = hasRows;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			try
			{
				var frmPromotion = new frmPromotion();
				var dialogResult = frmPromotion.ShowDialog();
				if (dialogResult != DialogResult.OK)
					return;

				promotionsTableAdapter.Insert(frmPromotion.Descrpition, frmPromotion.ProductId, frmPromotion.Quantity,
					frmPromotion.Discount, false);

				var newPromotionRow = storeDataSet.Promotions.NewPromotionsRow();
				newPromotionRow.Description = frmPromotion.Descrpition;
				newPromotionRow.ProductId = frmPromotion.ProductId;
				newPromotionRow.Quantity = frmPromotion.Quantity;
				newPromotionRow.Discount = frmPromotion.Discount;
				newPromotionRow.AllowMultiple = false;
				storeDataSet.Promotions.AddPromotionsRow(newPromotionRow);

				promotionsWithProductDetailsTableAdapter.Fill(storeDataSet.PromotionsWithProductDetails);

				dataGridView.CurrentCell = dataGridView.Rows.Last().Cells.First();
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			var row = GetCurrentPromotionRow();
			var frmProduct = new frmPromotion();
			var dialogResult = frmProduct.EditPromotion(row);
			if (dialogResult != DialogResult.OK)
				return;

			row.Description = frmProduct.Descrpition;
			row.ProductId = frmProduct.ProductId;
			row.Quantity = frmProduct.Quantity;
			row.Discount = frmProduct.Discount;

			var currentRow = dataGridView.CurrentCell.RowIndex;
			var currentCol = dataGridView.CurrentCell.ColumnIndex;
			var topVisibleRow = dataGridView.FirstDisplayedCell.RowIndex;
			var leftVisibleCol = dataGridView.FirstDisplayedCell.ColumnIndex;
				
			dataGridView.SuspendLayout();
			try
			{
				promotionsTableAdapter.Update(row);
				promotionsWithProductDetailsTableAdapter.Fill(storeDataSet.PromotionsWithProductDetails);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Update Promotion", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			dataGridView.FirstDisplayedCell = dataGridView[leftVisibleCol, topVisibleRow];
			dataGridView.CurrentCell = dataGridView[currentCol, currentRow];
			dataGridView.ResumeLayout();
		}

		private StoreDataSet.PromotionsRow GetCurrentPromotionRow()
		{
			Debug.Assert(dataGridView.CurrentRow != null, "dataGridView.CurrentRow != null");
			var rowView = dataGridView.CurrentRow.DataBoundItem as DataRowView;

			Debug.Assert(rowView != null, "rowView != null");
			var row = rowView.Row as StoreDataSet.PromotionsWithProductDetailsRow;

			Debug.Assert(row != null, "row != null");

			var promotionId = row.Id;

			return storeDataSet.Promotions.FindById(promotionId);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			var mbr = MessageBox.Show("Are you sure you want to delete the selected promotion?", "Delete promotion",
				MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

			if (mbr != DialogResult.Yes)
				return;

			var row = GetCurrentPromotionRow();
			var promotionId = row.Id;
			promotionsTableAdapter.Delete(row.Id, row.Description, row.ProductId, row.Quantity, row.Discount, row.AllowMultiple);
			row.Delete();

			var viewRow = storeDataSet.PromotionsWithProductDetails.FindById(promotionId);
			viewRow.Delete();
		}
	}
}
