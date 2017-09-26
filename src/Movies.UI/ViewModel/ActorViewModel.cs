using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using System;


namespace Movies.UI.ViewModel
{
	public class ActorViewModel : PersonViewModel
    {
		public Actor actor;
		public ActorViewModel(string name,
			string surname,
			DateTime birthDate,
			string biography,
			MyCollection<Film> films) : base(name, surname, birthDate)
		{
			actor = person as Actor;
			actor.Biography = biography;
			actor.Films = films;
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

		public MyCollection<Film> Films
		{
			get => actor.Films;
			set
			{
				actor.Films = value;
				OnPropertyChanged();
			}
		}

	}
}
