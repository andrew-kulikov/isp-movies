using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using Movies.UI.View;
using Movies.UI.ViewModel.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Movies.UI.ViewModel
{
	public class FilmViewModel : INotifyPropertyChanged
	{
		private Film film;
		MyObservableCollection<ActorViewModel> actors;
		private ActorViewModel selectedActor = null;
		private Dictionary<string, bool> dict;

		public FilmViewModel()
		{
			film = new Film();
			dict = new Dictionary<string, bool>();
			actors = new MyObservableCollection<ActorViewModel>();
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
				if (film.Rating != value)
				{
					film.Rating = value;
					OnPropertyChanged();
				}
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
			get => film.Genres;
			set
			{
				film.Genres = value;
				OnPropertyChanged();
			}
		} 
		public MyObservableCollection<ActorViewModel> Actors
		{
			get
			{
				if (actors.Count == 0)
				{
					actors = new MyObservableCollection<ActorViewModel>();
					foreach (Actor actor in film.Actors)
					{
						actors.Add(new ActorViewModel(actor));
					}
					OnPropertyChanged();
				}
				return actors;
			}
			set
			{
				actors = value;
				MyCollection<Actor> newActors = new MyCollection<Actor>();
				foreach (var t in value)
				{
					newActors.Add(t.SourceActor);
				}
				film.Actors = newActors;
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
				if (value != null)
				{
					selectedActor = value;
					OnPropertyChanged();
				}
			}
		}

		public Dictionary<string, bool> GenresDict
		{
			get => dict;
			set
			{
				dict = value;
				OnPropertyChanged();
			}
		}

		public void TransformGenres()
		{
			string genres = "";
			foreach (var genre in dict)
			{
				if (genre.Value)
				{
					genres += genre.Key + ", ";
				}
			}
			if (genres.Length != 0)
			{
				Genres = genres.Substring(0, genres.Length - 2);
			}
		}

		public bool IsReady()
		{
			if (Name == null || Name.Equals(null) || Name == "")
			{
				return false;
			}
			else if (Rating == -1)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public void Save(string path)
		{
			film.Save(path);
		}

		public void Initialize()
		{
			film.Initialize();
			
		}

		public void SetActorFilms(MyCollection<Film> films)
		{
			actors = new MyObservableCollection<ActorViewModel>();
			foreach (Actor actor in film.Actors)
			{
				actor.TransformFilms(films);
				actors.Add(new ActorViewModel(actor));
			}
		}

		public Film Source => film;

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
