using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BusinessLogic
{
	public abstract class Person 
	{
		private string name;
		private string surname;
		private DateTime birthDate;

		public Person(string name, string surname, DateTime birthDate)
		{
			this.name = name;
			this.surname = surname;
			this.birthDate = birthDate;
		}

		public string Name => name;

		public string Surname => surname;

		public DateTime BirthDate => birthDate;
	}
}
