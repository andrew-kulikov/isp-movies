using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Collections
{
	public class Actor : IComparable
	{
		private string name;
		private DateTime birthDate;
		private string[] biography = null;
		private MyCollection<Film> films = null;

		public Actor(string name, DateTime birthDate, string[] biography, MyCollection<Film> films)
		{
			this.name = name;
			this.birthDate = birthDate;
			this.biography = biography;
			this.films = films;
		}

		public string Name => name;
		public string[] Biography => biography;
		public MyCollection<Film> Films => films;

		public void AddFilm(Film film) => films.Add(film);
		public bool IsInFilm(Film film) => films.Contains(film);

		public DateTime BirthDate
		{
			get => birthDate;
		}

		public int CompareTo(object obj)
		{
			Actor actor = obj as Actor;
			if (actor.Equals(null)) throw new ArgumentNullException("Wrong type!");
			return name.CompareTo(actor.name);
		}
		public override string ToString()
		{
			string s = "";
			s += "Name: " + name;
			s += "\nBirth date: " + birthDate.Day + "." + birthDate.Month + "." + birthDate.Year;
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
