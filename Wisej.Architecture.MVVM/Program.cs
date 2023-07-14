using System;
using Wisej.Web;

namespace Wisej.Architecture.MVVM
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			//Application.MainPage = new Page1();
			new StudentViewModel(new Page1());
		}

		//
		// You can use the entry method below
		// to receive the parameters from the URL in the args collection.
		//
		//static void Main(NameValueCollection args)
		//{
		//}
	}
}