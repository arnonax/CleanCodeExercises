namespace LegacyApplication
{
	partial class frmProduct
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
			this.txtBarcode = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.mtbPrice = new System.Windows.Forms.MaskedTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.barcodeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.descriptionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.priceErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.barcodeErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.priceErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Barcode:";
			// 
			// txtBarcode
			// 
			this.txtBarcode.Location = new System.Drawing.Point(105, 13);
			this.txtBarcode.Name = "txtBarcode";
			this.txtBarcode.Size = new System.Drawing.Size(182, 22);
			this.txtBarcode.TabIndex = 1;
			this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(105, 42);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(182, 22);
			this.txtDescription.TabIndex = 3;
			this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "&Description:";
			// 
			// mtbPrice
			// 
			this.mtbPrice.Location = new System.Drawing.Point(105, 71);
			this.mtbPrice.Mask = "000.00";
			this.mtbPrice.Name = "mtbPrice";
			this.mtbPrice.Size = new System.Drawing.Size(100, 22);
			this.mtbPrice.TabIndex = 5;
			this.mtbPrice.TextChanged += new System.EventHandler(this.mtbPrice_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "&Price:";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(302, 141);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(119, 33);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "&Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Enabled = false;
			this.btnOK.Location = new System.Drawing.Point(170, 141);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(126, 33);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// barcodeErrorProvider
			// 
			this.barcodeErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.barcodeErrorProvider.ContainerControl = this;
			// 
			// descriptionErrorProvider
			// 
			this.descriptionErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.descriptionErrorProvider.ContainerControl = this;
			// 
			// priceErrorProvider
			// 
			this.priceErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.priceErrorProvider.ContainerControl = this;
			// 
			// frmProduct
			// 
			this.AcceptButton = this.btnOK;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(433, 186);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.mtbPrice);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.txtBarcode);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmProduct";
			this.Text = "Product";
			this.Load += new System.EventHandler(this.frmProduct_Load);
			((System.ComponentModel.ISupportInitialize)(this.barcodeErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.descriptionErrorProvider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.priceErrorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtBarcode;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.MaskedTextBox mtbPrice;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ErrorProvider barcodeErrorProvider;
		private System.Windows.Forms.ErrorProvider descriptionErrorProvider;
		private System.Windows.Forms.ErrorProvider priceErrorProvider;
	}
}
