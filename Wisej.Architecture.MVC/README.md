# Wisej.Architecture.MVC

## Setup
This project contains a connection string in the Web.Config file that provides information to connect to a SQL database called "StudentData" on the local machine. You will need a database with the correct name on your local machine, or the project will not be able to load the data.

The connection string in the Web.Config file looks like this:
<connectionStrings>
		<add name="Students" connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" providerName="System.Data.SqlClient"/>
	</connectionStrings>

You can download Sql Server Management Studio (SSMS) here: https://www.microsoft.com/en-us/sql-server/sql-server-downloads

Once you are in SSMS, load the database by right-clicking on "Databases", choose "Restore Database" and select the StudentData.bak file. You will then have a database called "StudentData" on your local machine. The database contains one table, "Students".
