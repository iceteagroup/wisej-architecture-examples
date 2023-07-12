using Wisej.Web;

namespace Wisej.Architecture.MVVM
{
	public partial class Page1 : Page
	{
		StudentViewModel studentViewModel;
		public Page1()
		{
			InitializeComponent();
			studentViewModel = new StudentViewModel();
		}

		private void Page1_Load(object sender, System.EventArgs e)
		{
			dataGridView1.DataSource = studentViewModel.studentdata;
		}
	}
}
