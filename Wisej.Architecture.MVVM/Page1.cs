using System;
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			//check to make sure that all the text fields have text (ie they are not the empty string)
			if (txtId.Text != "" && txtEmail.Text != "" && txtName.Text != "" && txtAge.Text != "")
			{
				//read the data from the text fields in the view
				int id = Int32.Parse(txtId.Text);
				string email = txtEmail.Text;
				string name = txtName.Text;
				int age = Int32.Parse(txtAge.Text);


				///////////////PUT THIS IN VIEWMODEL
				string message = studentViewModel.AddStudentToDatabase(name, id, age, email);
				AlertBox.Show(message);

				//clear the textboxes
				txtId.Text = "";
				txtEmail.Text = "";
				txtName.Text = "";
				txtAge.Text = "";

				//////////////PUT THIS IN VIEWMODEL
				////////Do databinding so this step is not necessary
				//Get the data from the database and show it in the view so that the new student is seen
				//studentdata = StudentModel.GetStudents();
				//dataGridView1.DataSource = studentdata;
			}
			else //if at least one of the text fields is blank
			{
				AlertBox.Show("Please enter values for all fields.");
			}
		}
	}
}
