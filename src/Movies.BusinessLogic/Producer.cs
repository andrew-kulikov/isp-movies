using Movies.BusinessLogic.Collections;
using System;

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

		public MyCollection<Film> Films
		{
			get => films;
			set => films = value;
		}
	}
}
