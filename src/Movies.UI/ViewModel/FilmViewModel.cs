using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using Movies.UI.ViewModel.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;


namespace Movies.UI.ViewModel
{
	public class FilmViewModel : INotifyPropertyChanged
	{
		private Film film;
		MyObservableCollection<ActorViewModel> actors;


		public FilmViewModel(Film film)
		{
			this.film = film;
		}

		public string Name
		{
			get => film.Name;
			set
			{
				film.Name = value;
				OnPropertyChanged();
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
			get => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images", film.PosterPath);
			set
			{
				film.PosterPath = value;
				OnPropertyChanged();
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

		public Producer Prod
		{
			get => film.Prod;
			set
			{
				film.Prod = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
