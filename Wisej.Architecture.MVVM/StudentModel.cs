
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace Wisej.Architecture.MVVM
{
	public class StudentModel
	{
		[Range(1, 999, ErrorMessage = "Id must be between 1 and 999")]
		public int Id { get; set; }

		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		public string Name { get; set; }
		public int Age { get; set; }

		// Returns a string either indicating that the given StudentModel is valid, or with an error message explaining which part(s) is invalid
		static public string ValidateData(StudentModel model, string validmessage)
		{
			string message = "";
			ValidationContext context = new ValidationContext(model, null, null);
			List<ValidationResult> validationResults = new List<ValidationResult>();
			bool valid = Validator.TryValidateObject(model, context, validationResults, true);
			if (!valid)
			{
				foreach (ValidationResult validationResult in
				validationResults)
				{
					message += validationResult.ErrorMessage + " \n";
				}
			}
			else
			{
				//check to make sure the ID does not match the ID of a student already in the database
				List<StudentModel> studentList = GetStudents();
				bool idAlreadyInDatabase = studentList.Any(p => p.Id == model.Id);
				if (idAlreadyInDatabase)
				{
					message += "That ID cannot be used, as there is already a student with that ID in the database. \n";
				}
				else
				{
					message = validmessage;
				}

			}
			return message;

		}

		// Looks up the database connection string. The database connection string is stored in Web.config.
		// In this case, the database connection string is just a the name of a JSON file.
		// If the database was a SQL server instead os a JSON file, the database connection string would look something like this:
		// Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
		public static string CnnVal(string name)
		{
			// code for if you are looking for a value in the Web.config file
			// return ConfigurationManager.ConnectionStrings[name].ConnectionString;

			// name parameter is unused, always returns same json file
			return "database.json";

		}

		// returns a list of StudentModel objects from the database
		public static List<StudentModel> GetStudents()
		{
			//read the file path of our database from the Web.config file
			string jsonDatabaseFilePath = StudentModel.CnnVal("Students");

			// Read the JSON file content
			string json = File.ReadAllText(jsonDatabaseFilePath);

			// Deserialize the JSON into a List<StudentModel>
			List<StudentModel> students = JsonConvert.DeserializeObject<List<StudentModel>>(json);

			return students;
		}

		// Adds the model to the database. Returns a string which contains an error message if the model is invalid.
		public string AddStudent()
		{
			string validMessage = "Added new student to the database.";

			// ValidateData returns a string with the validation errors. Returns validMessage if the data is valid.
			string message = StudentModel.ValidateData(this, validMessage);

			// if the data in the model is valid, add the student to the database
			if (message == validMessage)
			{
				//read the file path of our database from the Web.config file
				string jsonDatabaseFilePath = StudentModel.CnnVal("Students");

				//add the data to the database
				UpdateJsonFile(jsonDatabaseFilePath, this);

			}
			// If the data is not valid, add a bit to the message informing the user that the student was not added to the database.
			else
			{
				message += " New student was not added to database.";
			}

			return message;
		}

		// Adds a new StudentModel object, in JSON format, to the given JSON file.
		// the JSON file must contain at least 1 StudentModel object
		private void UpdateJsonFile(string jsonFilePath, StudentModel newStudent)
		{
			// Read the existing JSON file content
			string existingJson = File.ReadAllText(jsonFilePath);

			List<StudentModel> students = new List<StudentModel>();
			try
			{
				// Deserialize the existing JSON into a list of StudentModel objects
				// NOTE: This line causes an error if the file is empty or does not contain at least 1 StudentModel object
				students = JsonConvert.DeserializeObject<List<StudentModel>>(existingJson);

				// Add the new StudentModel object to the list
				students.Add(newStudent);

			}
			// If there are issues reading the student data from the JSON file, Create a new list containing the new student
			//catch exception that happens when the file has invalid JSON formatting
			catch (JsonSerializationException ex)
			{
				students = new List<StudentModel>();
				students.Add(this);
			}
			//catch exception that happens when the file is blank
			catch (NullReferenceException ex)
			{
				students = new List<StudentModel>();
				students.Add(this);
			}
			finally
			{
				// Serialize the updated list of StudentModel objects to JSON
				string updatedJson = JsonConvert.SerializeObject(students, Formatting.Indented);

				// Overwrite the existing JSON file with the updated JSON
				File.WriteAllText(jsonFilePath, updatedJson);
			}
		}
	}
}
