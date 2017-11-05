using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace Movies.UI.ViewModel
{
	public class ActorViewModel
    {
		private Actor actor;

		public ActorViewModel(Actor actor)
		{
			this.actor = actor;
		}

		public ActorViewModel()
		{
			actor = new Actor();
		}

		public ActorViewModel(string name,
			string surname,
			DateTime birthDate,
			string biography,
			MyCollection<Film> films)
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

		public string FullDate => actor.BirthDate.Day + "." + actor.BirthDate.Month + "." + actor.BirthDate.Year;

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

		public string Name
		{
			get => actor.Name;
			set
			{
				actor.Name = value;
				OnPropertyChanged();
			}
		}

		public string Surname
		{
			get => actor.Surname;
			set
			{
				actor.Surname = value;
				OnPropertyChanged();
			}
		}

		public int BirthDay
		{
			get => actor.BirthDate.Day;
			set => actor.BirthDate = new DateTime(actor.BirthDate.Year, actor.BirthDate.Month, value);
		}

		public int BirthMonth
		{
			get => actor.BirthDate.Month;
			set => actor.BirthDate = new DateTime(actor.BirthDate.Year, value, actor.BirthDate.Day);
		}

		public int BirthYear
		{
			get => actor.BirthDate.Year;
			set => actor.BirthDate = new DateTime(value, actor.BirthDate.Month, actor.BirthDate.Day);
		}

		public bool IsReady
		{
			get
			{
				if (Name == null || Name == "" || BirthDay == 0
					|| BirthMonth == 0 || Surname == null || Surname == "")
				{
					return false;
				}
				return true;
			}
		}

		public Actor SourceActor => actor;

		public string PersonIconPath => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images", "person.png");

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
