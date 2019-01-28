namespace LegacyApplication
{
	partial class frmPromotions
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.storeDataSet = new LegacyApplication.StoreDataSet();
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.promotionsWithProductDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.promotionsWithProductDetailsTableAdapter = new LegacyApplication.StoreDataSetTableAdapters.PromotionsWithProductDetailsTableAdapter();
			this.promotionsTableAdapter = new LegacyApplication.StoreDataSetTableAdapters.PromotionsTableAdapter();
			this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ProductDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.discountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.allowMultipleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.storeDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.promotionsWithProductDetailsBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Location = new System.Drawing.Point(862, 121);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(149, 48);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEdit.Location = new System.Drawing.Point(862, 65);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(149, 49);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "&Edit...";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(862, 12);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(149, 46);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "&Add...";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// storeDataSet
			// 
			this.storeDataSet.DataSetName = "StoreDataSet";
			this.storeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// dataGridView
			// 
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView.AutoGenerateColumns = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descriptionDataGridViewTextBoxColumn,
            this.ProductDescription,
            this.quantityDataGridViewTextBoxColumn,
            this.discountDataGridViewTextBoxColumn,
            this.allowMultipleDataGridViewCheckBoxColumn,
            this.barcodeDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
			this.dataGridView.DataSource = this.promotionsWithProductDetailsBindingSource;
			this.dataGridView.Location = new System.Drawing.Point(13, 13);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.ReadOnly = true;
			this.dataGridView.RowTemplate.Height = 24;
			this.dataGridView.Size = new System.Drawing.Size(843, 392);
			this.dataGridView.TabIndex = 0;
			// 
			// promotionsWithProductDetailsBindingSource
			// 
			this.promotionsWithProductDetailsBindingSource.DataMember = "PromotionsWithProductDetails";
			this.promotionsWithProductDetailsBindingSource.DataSource = this.storeDataSet;
			// 
			// promotionsWithProductDetailsTableAdapter
			// 
			this.promotionsWithProductDetailsTableAdapter.ClearBeforeFill = true;
			// 
			// promotionsTableAdapter
			// 
			this.promotionsTableAdapter.ClearBeforeFill = true;
			// 
			// descriptionDataGridViewTextBoxColumn
			// 
			this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
			this.descriptionDataGridViewTextBoxColumn.HeaderText = "Promotion Description";
			this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
			this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// ProductDescription
			// 
			this.ProductDescription.DataPropertyName = "ProductDescription";
			this.ProductDescription.HeaderText = "Product Description";
			this.ProductDescription.Name = "ProductDescription";
			this.ProductDescription.ReadOnly = true;
			// 
			// quantityDataGridViewTextBoxColumn
			// 
			this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
			this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
			this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
			this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
			this.quantityDataGridViewTextBoxColumn.ToolTipText = "The quantity of items from the specified Product that the customer need to buy in" +
    " order to get the discount";
			// 
			// discountDataGridViewTextBoxColumn
			// 
			this.discountDataGridViewTextBoxColumn.DataPropertyName = "Discount";
			dataGridViewCellStyle1.Format = "C2";
			dataGridViewCellStyle1.NullValue = null;
			this.discountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
			this.discountDataGridViewTextBoxColumn.HeaderText = "Discount";
			this.discountDataGridViewTextBoxColumn.Name = "discountDataGridViewTextBoxColumn";
			this.discountDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// allowMultipleDataGridViewCheckBoxColumn
			// 
			this.allowMultipleDataGridViewCheckBoxColumn.DataPropertyName = "AllowMultiple";
			this.allowMultipleDataGridViewCheckBoxColumn.HeaderText = "Allow Multiple";
			this.allowMultipleDataGridViewCheckBoxColumn.Name = "allowMultipleDataGridViewCheckBoxColumn";
			this.allowMultipleDataGridViewCheckBoxColumn.ReadOnly = true;
			this.allowMultipleDataGridViewCheckBoxColumn.ToolTipText = "Specifies whether the customer can receive the discount multiple times in the sam" +
    "e invoice - for each multiplication of Quantity";
			// 
			// barcodeDataGridViewTextBoxColumn
			// 
			this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "Barcode";
			this.barcodeDataGridViewTextBoxColumn.HeaderText = "Barcode";
			this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
			this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// priceDataGridViewTextBoxColumn
			// 
			this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
			this.priceDataGridViewTextBoxColumn.HeaderText = "Product\'s regular Price";
			this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
			this.priceDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// frmPromotions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1023, 428);
			this.Controls.Add(this.dataGridView);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Name = "frmPromotions";
			this.Text = "Promotions";
			this.Load += new System.EventHandler(this.frmPromotions_Load);
			((System.ComponentModel.ISupportInitialize)(this.storeDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.promotionsWithProductDetailsBindingSource)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnAdd;
		private StoreDataSet storeDataSet;
		private System.Windows.Forms.DataGridView dataGridView;
		private System.Windows.Forms.BindingSource promotionsWithProductDetailsBindingSource;
		private StoreDataSetTableAdapters.PromotionsWithProductDetailsTableAdapter promotionsWithProductDetailsTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn expr1DataGridViewTextBoxColumn;
		private StoreDataSetTableAdapters.PromotionsTableAdapter promotionsTableAdapter;
		private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn ProductDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn discountDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewCheckBoxColumn allowMultipleDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
	}
}