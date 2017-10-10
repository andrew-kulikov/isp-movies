using Movies.BusinessLogic.Collections;
using System;

namespace Movies.BusinessLogic
{
	public class Actor : Person
	{
		private string biography = null;
		private MyCollection<Film> films = null;

		public Actor()
		{
			films = new MyCollection<Film>();
			biography = "";
		}

		public Actor(string name,
			string surname,
			DateTime birthDate,
			string biography,
			MyCollection<Film> films) : base(name, surname, birthDate)
		{
			this.biography = biography;
			this.films = films;
		}

		public string Biography
		{
			get => biography;
			set
			{
				biography = value;
			}
		}
		public MyCollection<Film> Films
		{
			get => films;
			set => films = value;
		}

		public void AddFilm(Film film) => films.Add(film);
		public bool IsInFilm(Film film) => films.Contains(film);

		public override string ToString()
		{
			string s = "";
			s += "Name: " + Name;
			s += "\nBirth date: " + BirthDate.Day + "." + BirthDate.Month + "." + BirthDate.Year;
			s += "\nBiography: \n";
			for (int i = 0; i < biography.Length; i++)
			{
				s += biography[i] + "\n";
			}
			s += new string('=', 20) + '\n';

			foreach (Film film in films)
			{
				s += film + "\n";
			}
			return s;
		}
	}
}
