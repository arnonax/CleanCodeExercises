namespace LegacyApplication
{
	partial class frmSellingMode
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.dgvInvoice = new System.Windows.Forms.DataGridView();
			this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label2 = new System.Windows.Forms.Label();
			this.txtTotal = new System.Windows.Forms.TextBox();
			this.btnClearAll = new System.Windows.Forms.Button();
			this.productsTableAdapter = new LegacyApplication.StoreDataSetTableAdapters.ProductsTableAdapter();
			this.dgvPromotions = new System.Windows.Forms.DataGridView();
			this.colPromotionDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.promotionsTableAdapter = new LegacyApplication.StoreDataSetTableAdapters.PromotionsTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPromotions)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Barcode:";
			// 
			// txtBarcode
			// 
			this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBarcode.Location = new System.Drawing.Point(83, 21);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(448, 22);
			this.txtBarcode.TabIndex = 1;
			this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Enabled = false;
			this.btnAdd.Location = new System.Drawing.Point(537, 13);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(113, 38);
			this.btnAdd.TabIndex = 2;
			this.btnAdd.Text = "&Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// dgvInvoice
			// 
			this.dgvInvoice.AllowUserToAddRows = false;
			this.dgvInvoice.AllowUserToDeleteRows = false;
			this.dgvInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBarcode,
            this.colDescription,
            this.colPrice});
			this.dgvInvoice.Location = new System.Drawing.Point(12, 58);
			this.dgvInvoice.Name = "dgvInvoice";
			this.dgvInvoice.ReadOnly = true;
			this.dgvInvoice.RowTemplate.Height = 24;
			this.dgvInvoice.Size = new System.Drawing.Size(638, 217);
			this.dgvInvoice.TabIndex = 3;
			// 
			// colBarcode
			// 
			this.colBarcode.HeaderText = "Barcode";
			this.colBarcode.Name = "colBarcode";
			this.colBarcode.ReadOnly = true;
			// 
			// colDescription
			// 
			this.colDescription.HeaderText = "Description";
			this.colDescription.Name = "colDescription";
			this.colDescription.ReadOnly = true;
			this.colDescription.Width = 200;
			// 
			// colPrice
			// 
			dataGridViewCellStyle1.Format = "C2";
			dataGridViewCellStyle1.NullValue = null;
			this.colPrice.DefaultCellStyle = dataGridViewCellStyle1;
			this.colPrice.HeaderText = "Price";
			this.colPrice.Name = "colPrice";
			this.colPrice.ReadOnly = true;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(439, 422);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 17);
			this.label2.TabIndex = 5;
			this.label2.Text = "Total:";
			// 
			// txtTotal
			// 
			this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTotal.Location = new System.Drawing.Point(489, 416);
			this.txtTotal.Name = "txtTotal";
			this.txtTotal.ReadOnly = true;
			this.txtTotal.Size = new System.Drawing.Size(161, 26);
			this.txtTotal.TabIndex = 6;
			// 
			// btnClearAll
			// 
			this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClearAll.Location = new System.Drawing.Point(12, 405);
			this.btnClearAll.Name = "btnClearAll";
			this.btnClearAll.Size = new System.Drawing.Size(122, 36);
			this.btnClearAll.TabIndex = 4;
			this.btnClearAll.Text = "Clear all";
			this.btnClearAll.UseVisualStyleBackColor = true;
			this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
			// 
			// productsTableAdapter
			// 
			this.productsTableAdapter.ClearBeforeFill = true;
			// 
			// dgvPromotions
			// 
			this.dgvPromotions.AllowUserToAddRows = false;
			this.dgvPromotions.AllowUserToDeleteRows = false;
			this.dgvPromotions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvPromotions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPromotions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPromotionDescription,
            this.colDiscount});
			this.dgvPromotions.Location = new System.Drawing.Point(12, 308);
			this.dgvPromotions.Name = "dgvPromotions";
			this.dgvPromotions.ReadOnly = true;
			this.dgvPromotions.RowTemplate.Height = 24;
			this.dgvPromotions.Size = new System.Drawing.Size(638, 91);
			this.dgvPromotions.TabIndex = 7;
			// 
			// colPromotionDescription
			// 
			this.colPromotionDescription.HeaderText = "Description";
			this.colPromotionDescription.Name = "colPromotionDescription";
			this.colPromotionDescription.ReadOnly = true;
			// 
			// colDiscount
			// 
			this.colDiscount.HeaderText = "Discount";
			this.colDiscount.Name = "colDiscount";
			this.colDiscount.ReadOnly = true;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 282);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "Discounts:";
			// 
			// promotionsTableAdapter
			// 
			this.promotionsTableAdapter.ClearBeforeFill = true;
			// 
			// frmSellingMode
			// 
			this.AcceptButton = this.btnAdd;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(662, 453);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dgvPromotions);
			this.Controls.Add(this.btnClearAll);
			this.Controls.Add(this.txtTotal);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dgvInvoice);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.txtBarcode);
			this.Controls.Add(this.label1);
			this.Name = "frmSellingMode";
			this.Text = "Selling mode";
			this.Load += new System.EventHandler(this.frmSellingMode_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvInvoice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPromotions)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.DataGridView dgvInvoice;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtTotal;
		private System.Windows.Forms.Button btnClearAll;
		private StoreDataSetTableAdapters.ProductsTableAdapter productsTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
		private System.Windows.Forms.DataGridView dgvPromotions;
		private System.Windows.Forms.DataGridViewTextBoxColumn colPromotionDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
		private System.Windows.Forms.Label label3;
		private StoreDataSetTableAdapters.PromotionsTableAdapter promotionsTableAdapter;
	}
}