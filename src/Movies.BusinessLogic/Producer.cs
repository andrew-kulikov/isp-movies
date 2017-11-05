using Movies.BusinessLogic.Collections;
using Movies.DataAcsessLayer;
using System;

namespace Movies.BusinessLogic
{
	public class Producer : Person
	{
		private MyCollection<Film> films;
		private MyCollection<string> filmNames;

		public Producer() : base()
		{
			films = new MyCollection<Film>();
		}

		public Producer(string name, string surname, DateTime birthDate, MyCollection<Film> films)
			:base(name, surname, birthDate)
		{
			this.films = films;
		}

		public ProducerModel ToDataModel()
		{
			ProducerModel model = new ProducerModel()
			{
				Name = Name,
				Surname = Surname,
				BirthDate = BirthDate
			};
			MyCollection<string> names = new MyCollection<string>();
			foreach (var film in films)
			{
				names.Add(film.Name);
			}
			model.Films = names.ToArray();
			return model;
		}
		public MyCollection<string> FilmNames { get => filmNames; set => filmNames = value; }
		public void Initialize(ProducerModel model)
		{
			Name = model.Name;
			Surname = model.Surname;
			BirthDate = model.BirthDate;
			FilmNames = new MyCollection<string>(model.Films);
		}

		public MyCollection<Film> Films
		{
			get => films;
			set => films = value;
		}
	}
}
