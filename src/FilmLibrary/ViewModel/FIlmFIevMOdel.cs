using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FilmLibrary.Model;

namespace FilmLibrary.ViewModel
{
	class FilmFievModel : INotifyPropertyChanged
	{
		private Film selectedFilm;
		public ObservableCollection<Film> Films { get; set; }
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
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
