using Movies.BusinessLogic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Movies.UI.ViewModel
{
	class FilmViewModel : INotifyPropertyChanged
	{
		private Film film;
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

		public string PosterPath
		{
			get => film.PosterPath;
			set
			{
				film.PosterPath = value;
				OnPropertyChanged();
			}
		}

		public string[] Genres
		{
			get => film.Genres;
			set
			{
				film.Genres = value;
				OnPropertyChanged();
			}
		} 
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
		/*public ObservableCollection<Film> Films { get; set; }
		public string CurrentTitle { get; set; }
		public string CurrentAge { get; set; }
		public Film SelectedFilm
		{
			get => selectedFilm;
			set
			{
				selectedFilm = value;
				OnPropertyChanged();
			}
		}
		private RelayCommand addCommand;
		public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(obj => Add()));
		public FilmFievModel()
		{
			Films = new ObservableCollection<Film>
			{
				new Film ("One",  18),
				new Film ("Next", 14),
				new Film ("Alien", 24)
			};
		}
		public void Add()
		{
			if (!string.IsNullOrEmpty(CurrentTitle) && !string.IsNullOrEmpty(CurrentAge))
			{
				Film cur = new Film(CurrentTitle, Int32.Parse(CurrentAge));
				SelectedFilm = cur;
				Films.Add(cur);
			}
		}*/
	}
}
