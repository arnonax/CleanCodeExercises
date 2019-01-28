namespace LegacyApplication
{
	partial class frmMainMenu
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
			this.btnProducts = new System.Windows.Forms.Button();
			this.btnSellingMode = new System.Windows.Forms.Button();
			this.btnPromotions = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnProducts
			// 
			this.btnProducts.Location = new System.Drawing.Point(13, 12);
			this.btnProducts.Name = "btnProducts";
			this.btnProducts.Size = new System.Drawing.Size(129, 49);
			this.btnProducts.TabIndex = 0;
			this.btnProducts.Text = "Products...";
			this.btnProducts.UseVisualStyleBackColor = true;
			this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
			// 
			// btnSellingMode
			// 
			this.btnSellingMode.Location = new System.Drawing.Point(13, 125);
			this.btnSellingMode.Name = "btnSellingMode";
			this.btnSellingMode.Size = new System.Drawing.Size(129, 53);
			this.btnSellingMode.TabIndex = 2;
			this.btnSellingMode.Text = "Selling mode...";
			this.btnSellingMode.UseVisualStyleBackColor = true;
			this.btnSellingMode.Click += new System.EventHandler(this.btnSellingMode_Click);
			// 
			// btnPromotions
			// 
			this.btnPromotions.Location = new System.Drawing.Point(13, 68);
			this.btnPromotions.Name = "btnPromotions";
			this.btnPromotions.Size = new System.Drawing.Size(129, 51);
			this.btnPromotions.TabIndex = 1;
			this.btnPromotions.Text = "&Promotions...";
			this.btnPromotions.UseVisualStyleBackColor = true;
			this.btnPromotions.Click += new System.EventHandler(this.btnPromotions_Click);
			// 
			// frmMainMenu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(153, 196);
			this.Controls.Add(this.btnPromotions);
			this.Controls.Add(this.btnSellingMode);
			this.Controls.Add(this.btnProducts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMainMenu";
			this.Text = "Main Menu";
			this.Load += new System.EventHandler(this.frmMainMenu_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnProducts;
		private System.Windows.Forms.Button btnSellingMode;
		private System.Windows.Forms.Button btnPromotions;
	}
}

