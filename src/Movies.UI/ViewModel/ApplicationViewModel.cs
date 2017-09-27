using Movies.BusinessLogic;
using Movies.UI.ViewModel.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Movies.UI.ViewModel
{
	public class ApplicationViewModel : INotifyPropertyChanged
	{
		private MyObservableCollection<Film> films;

		public ApplicationViewModel()
		{
			Film[] f = new Film[]
			{
				new Film("It", "1.jpg", 18, 2017, 6.3, new [] {"1", "2", "3"}),
				new Film("Avatar", "2.jpg", 12, 2009, 8.5, new [] {"5", "2", "7"}),
				new Film("Free to play", "3.jpg", 12, 2014, 5.4, new [] {"8", "4"}),
				new Film("DDD", "4.jpg", 21, 2045, 5.6, new [] {"1", "2", "3"})
			};
			films = new MyObservableCollection<Film>(f);
		}

		public MyObservableCollection<Film> Films
		{
			get => films;
			set
			{
				films = value;
				OnPropertyChanged();
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
