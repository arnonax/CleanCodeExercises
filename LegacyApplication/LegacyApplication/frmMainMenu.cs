using System.Windows.Forms;

namespace LegacyApplication
{
	public partial class frmMainMenu : Form
	{
		public frmMainMenu()
		{
			InitializeComponent();
		}

		private void btnProducts_Click(object sender, System.EventArgs e)
		{
			new frmProducts().ShowDialog();
		}

		private void frmMainMenu_Load(object sender, System.EventArgs e)
		{

		}

		private void btnSellingMode_Click(object sender, System.EventArgs e)
		{
			new frmSellingMode().ShowDialog();
		}

		private void btnPromotions_Click(object sender, System.EventArgs e)
		{
			new frmPromotions().ShowDialog();
		}
	}
}
