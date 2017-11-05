using Movies.BusinessLogic.Collections;
using Newtonsoft.Json;
using Movies.DataAcsessLayer;
using System;

namespace Movies.BusinessLogic
{
	public class Actor : Person
	{
		private string biography = null;
		private MyCollection<string> filmNames;
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

		public MyCollection<string> FilmNames { get => filmNames; set => filmNames = value; }

		public ActorModel ToDataModel()
		{
			ActorModel model = new ActorModel()
			{
				Name = Name,
				Surname = Surname,
				BirthDate = BirthDate,
				Biography = biography
			};
			MyCollection<string> names = new MyCollection<string>();
			foreach (var film in films)
			{
				names.Add(film.Name);
			}
			model.Films = names.ToArray();
			return model;
		}

		public void TransformFilms(MyCollection<Film> allFilms)
		{
			MyCollection<Film> newFilms = new MyCollection<Film>();
			foreach (string fname in FilmNames)
			{
				foreach (Film film in allFilms)
				{
					if (film.Name == fname)
					{
						newFilms.Add(film);
					}
				}
			}
			Films = newFilms;
		}

		public void Initialize(ActorModel model)
		{
			if (model == null) throw new NullReferenceException();
			Name = model.Name;
			Surname = model.Surname;
			BirthDate = model.BirthDate;
			biography = model.Biography;
			FilmNames = new MyCollection<string>(model.Films); 
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
