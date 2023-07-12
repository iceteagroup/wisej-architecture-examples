
using System.Collections.Generic;
using System.Xml.Linq;

namespace Wisej.Architecture.MVVM
{
	public class StudentViewModel
	{
		public List<StudentModel> studentdata;
		public StudentViewModel()
		{
			//studentdata = new List<StudentModel>();
			studentdata = StudentModel.GetStudents();
		}
		public string AddStudentToDatabase(string name, int id, int age, string email)
		{
			// create a StudentModel based on the data in the text fields.
			StudentModel model = new StudentModel() { Name = name, Id = id, Age = age, Email = email };
			// Attempt to add the student to the database- returns a sucess or failure message.
			string message = model.AddStudent();
			return message;
		}
	}
}
