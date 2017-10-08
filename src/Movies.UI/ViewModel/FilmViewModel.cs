﻿using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using Movies.UI.View;
using Movies.UI.ViewModel.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;

namespace Movies.UI.ViewModel
{
	public class FilmViewModel : INotifyPropertyChanged
	{
		private Film film;
		MyObservableCollection<ActorViewModel> actors;
		private ActorViewModel selectedActor = null;

		public FilmViewModel()
		{
			film = new Film();
		}


		public FilmViewModel(Film film)
		{
			actors = new MyObservableCollection<ActorViewModel>();
			this.film = film;
		}

		public string Name
		{
			get => film.Name;
			set
			{
				film.Name = value;
				OnPropertyChanged();
				OnPropertyChanged("NewFilm");
			}
		}
		
		public int AgeLimit
		{
			get => film.AgeLimit;
			set
			{
				film.AgeLimit = value;
				OnPropertyChanged();
			}

		}

		public int YearOfRelease
		{
			get => film.YearOfRelease;
			set
			{
				film.YearOfRelease = value;
				OnPropertyChanged();
			}
		}

		public double Rating
		{
			get => film.Rating;
			set
			{
				film.Rating = value;
				OnPropertyChanged();
			}
		}

		public string Description
		{
			get => film.Description;
			set
			{
				film.Description = value;
				OnPropertyChanged();
			}
		} 

		public string PosterPath
		{
			get
			{
				string directory = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images");
				if (File.Exists(directory + "//" + film.Name + ".jpg"))
				{
					return directory + "//" + film.Name + ".jpg";
				}
				else
				{
					return directory + "//default.png";
				}
			}
		}

		public string Genres
		{
			get => string.Join(",", film.Genres);
			set
			{
				film.Genres = value.Split(',');
				OnPropertyChanged();
			}
		} 

		public MyObservableCollection<ActorViewModel> Actors
		{
			get => actors;
			set
			{
				actors = value;
				film.Actors = new MyCollection<Actor>();
				foreach (var t in value)
				{
					film.Actors.Add(t.SourceActor);
				}
				OnPropertyChanged();
			}
		}

		public MyObservableCollection<string> ActorNames
		{
			get
			{
				MyObservableCollection<string> names = new MyObservableCollection<string>();
				foreach (Actor actor in film.Actors)
				{
					names.Add(actor.Name + " " + actor.Surname);
				}
				return names;
			}
		}

		public string ProducerName => Prod.Name + " " + Prod.Surname;

		public Producer Prod
		{
			get => film.Prod;
			set
			{
				film.Prod = value;
				OnPropertyChanged();
			}
		}

		public ActorViewModel SelectedActor
		{
			get => selectedActor;
			set
			{
				selectedActor = value;
				ActorInfo af = new ActorInfo(selectedActor);
				af.ShowDialog();
				OnPropertyChanged();
			}
		}

		private Dictionary<string, int> dict;
		public Dictionary<string, int> GenresDict
		{
			get => dict;
			set
			{
				dict = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
