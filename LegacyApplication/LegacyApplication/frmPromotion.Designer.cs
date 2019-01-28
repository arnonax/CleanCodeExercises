namespace LegacyApplication
{
	partial class frmPromotion
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.cboProduct = new System.Windows.Forms.ComboBox();
			this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.storeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.storeDataSet = new LegacyApplication.StoreDataSet();
			this.label2 = new System.Windows.Forms.Label();
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtProductPrice = new System.Windows.Forms.TextBox();
			this.nudQuantity = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.mtbDiscount = new System.Windows.Forms.MaskedTextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.productsTableAdapter = new LegacyApplication.StoreDataSetTableAdapters.ProductsTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.storeDataSetBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.storeDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Description:";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(117, 14);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(345, 22);
			this.txtDescription.TabIndex = 1;
			this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
			// 
			// cboProduct
			// 
			this.cboProduct.DataSource = this.productsBindingSource;
			this.cboProduct.DisplayMember = "Description";
			this.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboProduct.FormattingEnabled = true;
			this.cboProduct.Location = new System.Drawing.Point(117, 42);
			this.cboProduct.Name = "cboProduct";
			this.cboProduct.Size = new System.Drawing.Size(345, 24);
			this.cboProduct.TabIndex = 3;
			this.cboProduct.SelectedIndexChanged += new System.EventHandler(this.cboProduct_SelectedIndexChanged);
			// 
			// productsBindingSource
			// 
			this.productsBindingSource.DataMember = "Products";
			this.productsBindingSource.DataSource = this.storeDataSetBindingSource;
			// 
			// storeDataSetBindingSource
			// 
			this.storeDataSetBindingSource.DataSource = this.storeDataSet;
			this.storeDataSetBindingSource.Position = 0;
			// 
			// storeDataSet
			// 
			this.storeDataSet.DataSetName = "StoreDataSet";
			this.storeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "&Product:";
			// 
			// txtBarcode
			// 
			this.txtBarcode.Location = new System.Drawing.Point(117, 73);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.ReadOnly = true;
			this.txtBarcode.Size = new System.Drawing.Size(100, 22);
			this.txtBarcode.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 76);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Barcode:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 17);
			this.label4.TabIndex = 6;
			this.label4.Text = "Regular price:";
			// 
			// txtProductPrice
			// 
			this.txtProductPrice.Location = new System.Drawing.Point(117, 101);
			this.txtProductPrice.Name = "txtProductPrice";
			this.txtProductPrice.ReadOnly = true;
			this.txtProductPrice.Size = new System.Drawing.Size(100, 22);
			this.txtProductPrice.TabIndex = 7;
			// 
			// nudQuantity
			// 
			this.nudQuantity.Location = new System.Drawing.Point(117, 130);
			this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudQuantity.Name = "nudQuantity";
			this.nudQuantity.Size = new System.Drawing.Size(120, 22);
			this.nudQuantity.TabIndex = 9;
			this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nudQuantity.ValueChanged += new System.EventHandler(this.nudQuantity_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 130);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 17);
			this.label5.TabIndex = 8;
			this.label5.Text = "&Quantity:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 161);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 17);
			this.label6.TabIndex = 10;
			this.label6.Text = "&Discount:";
			// 
			// mtbDiscount
			// 
			this.mtbDiscount.Location = new System.Drawing.Point(117, 158);
			this.mtbDiscount.Mask = "000.00";
			this.mtbDiscount.Name = "mtbDiscount";
			this.mtbDiscount.Size = new System.Drawing.Size(100, 22);
			this.mtbDiscount.TabIndex = 11;
			this.mtbDiscount.TextChanged += new System.EventHandler(this.mtbDiscount_TextChanged);
			// 
			// btnOK
			// 
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(303, 203);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(126, 33);
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(435, 203);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(119, 33);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.errorProvider.ContainerControl = this;
			// 
			// productsTableAdapter
			// 
			this.productsTableAdapter.ClearBeforeFill = true;
			// 
			// frmPromotion
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(566, 248);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.mtbDiscount);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.nudQuantity);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtProductPrice);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtBarcode);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cboProduct);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmPromotion";
			this.Text = "Promotion";
			this.Load += new System.EventHandler(this.frmPromotion_Load);
			((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.storeDataSetBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.storeDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.ComboBox cboProduct;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtProductPrice;
		private System.Windows.Forms.NumericUpDown nudQuantity;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.MaskedTextBox mtbDiscount;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.BindingSource storeDataSetBindingSource;
		private StoreDataSet storeDataSet;
		private System.Windows.Forms.BindingSource productsBindingSource;
		private StoreDataSetTableAdapters.ProductsTableAdapter productsTableAdapter;
	}
}