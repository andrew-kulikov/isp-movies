using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using System;


namespace Movies.UI.ViewModel
{
	public class ActorViewModel : PersonViewModel
    {
		private Actor actor;

		public ActorViewModel(string name,
			string surname,
			DateTime birthDate,
			string biography,
			MyCollection<Film> films) : base(name, surname, birthDate)
		{
			actor = new Actor(name, surname, birthDate, biography, films);
		}

		public string Biography
		{
			get => actor.Biography;
			set
			{
				actor.Biography = value;
				OnPropertyChanged();
			}
		}

		public string FullDate => BirthDate.Day + "." + BirthDate.Month + "." + BirthDate.Year;

		public string FullName => actor.Name + " " + actor.Surname;

		public MyCollection<Film> Films
		{
			get => actor.Films;
			set
			{
				actor.Films = value;
				OnPropertyChanged();
			}
		}

		public Actor SourceActor => actor;

	}
}
