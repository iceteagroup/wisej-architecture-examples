
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Wisej.Web;

namespace Wisej.Architecture.MVVM
{
	public class StudentViewModel : INotifyPropertyChanged
	{
		private Page _form;

		private BindingSource _bindingSource;

		#region Constructor

		public StudentViewModel()
		{
			_bindingSource = new BindingSource(_studentData, null);
		}

		public StudentViewModel(Page frm)
		{
			_studentData = StudentModel.GetStudents();
			_bindingSource = new BindingSource(_studentData, null);
			_form = frm;

			this._form.Show();

			AttachDataSourceToDataGridView();
			AddDataBindingToTextBoxes();

			//Get the "button1" control from the form
			Button button1 = (Button)_form.Controls["button1"];

			//Add an event handler to the "Click" event of the "button1" control
			button1.Click += button1_Click;

			//Get the "button2" control from the form
			Button button2 = (Button)_form.Controls["button2"];

			//Add an event handler to the "Click" event of the "button2" control
			button2.Click += button2_Click;
		}

		#endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(propertyName);

			return true;
		}

		#endregion

		#region Properties

		private List<StudentModel> StudentData
		{
			get { return _studentData; }
			set { SetField(ref _studentData, value); }
		}
		private List<StudentModel> _studentData;

		#endregion

		#region Methods

		//Create a method to remove the binding on the textboxes
		public void RemoveDataBindingFromTextBoxes()
		{
			//Get the "txtId" control from the form
			TextBox txtId = (TextBox)_form.Controls["txtId"];

			//Get the "txtEmail" control from the form
			TextBox txtEmail = (TextBox)_form.Controls["txtEmail"];

			//Get the "txtName" control from the form
			TextBox txtName = (TextBox)_form.Controls["txtName"];

			//Get the "txtAge" control from the form
			TextBox txtAge = (TextBox)_form.Controls["txtAge"];

			//Remove the data binding from the "Text" property of the "txtId" control
			txtId.DataBindings.Clear();

			//Remove the data binding from the "Text" property of the "txtEmail" control
			txtEmail.DataBindings.Clear();

			//Remove the data binding from the "Text" property of the "txtName" control
			txtName.DataBindings.Clear();

			//Remove the data binding from the "Text" property of the "txtAge" control
			txtAge.DataBindings.Clear();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			ClearTextBoxes();

			RemoveDataBindingFromTextBoxes();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			AddStudentMVVM();

			AddDataBindingToTextBoxes();
		}

		public void AttachDataSourceToDataGridView()
		{
			//Get the "datagridview1" control from the form
			DataGridView dataGridView1 = (DataGridView)_form.Controls["dataGridView1"];

			//Bind the "StudentData" list to the "DataSource" property of the "datagridview1" control
			dataGridView1.DataSource = _bindingSource;
		}

		public void AddDataBindingToTextBoxes()
		{
			//Get the "txtId" control from the form
			TextBox txtId = (TextBox)_form.Controls["txtId"];

			//Get the "txtEmail" control from the form
			TextBox txtEmail = (TextBox)_form.Controls["txtEmail"];

			//Get the "txtName" control from the form
			TextBox txtName = (TextBox)_form.Controls["txtName"];

			//Get the "txtAge" control from the form
			TextBox txtAge = (TextBox)_form.Controls["txtAge"];

			//Bind the "Id" property of the StudentModel to the "Text" property of the "txtId" control
			txtId.DataBindings.Add("Text", this._bindingSource, "Id");

			//Bind the "Email" property of the StudentModel to the "Text" property of the "txtEmail" control
			txtEmail.DataBindings.Add("Text", this._bindingSource, "Email");

			//Bind the "Name" property of the StudentModel to the "Text" property of the "txtName" control
			txtName.DataBindings.Add("Text", this._bindingSource, "Name");

			//Bind the "Age" property of the StudentModel to the "Text" property of the "txtAge" control
			txtAge.DataBindings.Add("Text", this._bindingSource, "Age");
		}

		//Clear all textboxes
		public void ClearTextBoxes()
		{
			//Get the "txtId" control from the form
			TextBox txtId = (TextBox)_form.Controls["txtId"];

			//Get the "txtEmail" control from the form
			TextBox txtEmail = (TextBox)_form.Controls["txtEmail"];

			//Get the "txtName" control from the form
			TextBox txtName = (TextBox)_form.Controls["txtName"];

			//Get the "txtAge" control from the form
			TextBox txtAge = (TextBox)_form.Controls["txtAge"];

			//Clear the "Text" property of the "txtId" control
			txtId.Text = "";

			//Clear the "Text" property of the "txtEmail" control
			txtEmail.Text = "";

			//Clear the "Text" property of the "txtName" control
			txtName.Text = "";

			//Clear the "Text" property of the "txtAge" control
			txtAge.Text = "";
		}

		public void AddStudentMVVM()
		{
			//Get the "txtId" control from the form
			TextBox txtId = (TextBox)_form.Controls["txtId"];

			//Get the "txtEmail" control from the form
			TextBox txtEmail = (TextBox)_form.Controls["txtEmail"];

			//Get the "txtName" control from the form
			TextBox txtName = (TextBox)_form.Controls["txtName"];

			//Get the "txtAge" control from the form
			TextBox txtAge = (TextBox)_form.Controls["txtAge"];

			//read the data from the text fields in the view
			int id = Int32.Parse(txtId.Text);
			string email = txtEmail.Text;
			string name = txtName.Text;
			int age = Int32.Parse(txtAge.Text);

			AddStudentToDatabase(name, id, age, email);
		}

		//Add a new student to the database
		private bool AddStudentToDatabase(string name, int id, int age, string email)
		{
			// create a StudentModel based on the data in the text fields.
			StudentModel model = new StudentModel() { Name = name, Id = id, Age = age, Email = email };

			// Attempt to add the student to the database- returns a sucess or failure message.
			var isAdded = model.AddStudent();

			if (!isAdded)
			{
				AlertBox.Show("Failed to add student to database");
				return false;
			}

			_studentData.Add(model);
			_bindingSource.ResetBindings(false);

			OnPropertyChanged(nameof(StudentData));

			return true;

		}

		#endregion

	}
}
