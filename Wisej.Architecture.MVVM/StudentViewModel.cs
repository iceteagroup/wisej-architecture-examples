using System.Collections.Generic;

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
	}
}
