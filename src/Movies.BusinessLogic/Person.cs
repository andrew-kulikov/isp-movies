using System;

namespace Movies.BusinessLogic
{
	public class Person 
	{
		private string name;
		private string surname;
		private DateTime birthDate;

		public Person()
		{

		}

		public Person(string name, string surname, DateTime birthDate)
		{
			this.name = name;
			this.surname = surname;
			this.birthDate = birthDate;
		}

		public string Name
		{
			get => name;
			set => name = value;
		}

		public string Surname
		{
			get => surname;
			set => surname = value;
		}

		public DateTime BirthDate
		{
			get => birthDate;
			set => birthDate = value;
		}
	}
}
