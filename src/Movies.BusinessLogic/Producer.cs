using Movies.BusinessLogic.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BusinessLogic
{
	public class Producer : Person
	{
		private MyCollection<Film> films;

		public Producer(string name, string surname, DateTime birthDate, MyCollection<Film> films)
			:base(name, surname, birthDate)
		{
			this.films = films;
		}

		public Film[] Films => films.ToArray();
	}
}
