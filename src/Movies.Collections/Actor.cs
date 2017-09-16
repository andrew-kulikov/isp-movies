using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Collections
{
	class Actor : IComparable
	{
		string name;
		(int day, int month, int year) birthDate;
		string[] biography = null;
		MyCollection<Film> films = null;

		public Actor(string name, (int, int, int) birthDate, string[] biography, MyCollection<Film> films)
		{
			this.name = name;
			BirthDate = birthDate;
			this.biography = biography;
			this.films = films;
		}

		public string Name => name;
		//public (int, int, int) BirthDate => BirthDate;
		public string[] Biography => biography;
		public MyCollection<Film> Films => films;

		public void AddFilm(Film film) => films.Add(film);
		public bool IsInFilm(Film film) => films.Contains(film);

		public (int, int, int) BirthDate
		{
			get => birthDate;
			set
			{
				if (value.Item3 >= 0 && value.Item3 <= DateTime.Now.Year 
					&& value.Item2 >= 1 && value.Item2 <= 12 
					&& value.Item1 >= 1 && value.Item1 <= DateTime.DaysInMonth(value.Item3, value.Item2))
				{
					if (value.Item3 == DateTime.Now.Year)
					{
						if (value.Item2 > DateTime.Now.Month
							|| value.Item2 == DateTime.Now.Month && value.Item1 > DateTime.Now.Day)
							throw new Exception("Wrong date");
					}
					birthDate = value;
				}
				else
				{
					throw new Exception("Wrong date");
				}
			}
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
			s += "\nBirth date: " + birthDate.day + "." + birthDate.month + "." + birthDate.year;
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
