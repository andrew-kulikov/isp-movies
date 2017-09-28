using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using Movies.UI.ViewModel.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Movies.UI.ViewModel
{
	public class ApplicationViewModel : INotifyPropertyChanged
	{
		private MyObservableCollection<FilmViewModel> films;
		private FilmViewModel selectedFilm;

		public ApplicationViewModel()
		{
			FilmViewModel[] f = new FilmViewModel[]
			{
				new FilmViewModel(new Film(
					"Digimon",
					"3090.jpg",
					18,
					2017,
					6.3,
					new [] {"1", "2", "3"},
					"A group of young teens is unexpectedly sent to the mysterious Digital World and paired up with their own powerful, morphing monster called the Digimon. Together the entire group set out on an adventure to fight evil and save the world.")),
				new FilmViewModel(new Film(
					"White Noise 2",
					"3096.jpg",
					12,
					2007,
					5.7,
					new [] {"5", "2", "7"},
					"Following the loss of his family, a man attempts suicide only to discover upon waking that he can identify people who are about to die")),
				new FilmViewModel(new Film(
					"Safety Not Guaranteed",
					"3151.jpg", 
					12, 
					2012, 
					7.0, 
					new [] {"8", "4"},
					"Three magazine employees head out on an assignment to interview a guy who placed a classified advertisement seeking a companion for time travel.")),
				new FilmViewModel(new Film(
					"Four brothers", 
					"3117.jpg", 
					21, 
					2005, 
					5.6, 
					new [] {"1", "2", "3"},
					"Four adopted brothers come to avenge their mother's death in what appears to be a random killing in a grocery store robbery. However, the boys' investigation of the death reveals more nefarious activities involving the one brother's business dealings with a notorious local hoodlum. Two cops who are trying to solve the case may also not be what they seem."))
			};
			/*MyCollection<Actor> actors = new MyCollection<Actor>(
				new Actor[] {
					new Actor(
						"Peter",
						"Parker",
						new System.DateTime(1956, 4, 24),
						"One of the first things I did was to work up a costume. A vital, visual part of the character. I had to know how he looked ... before I did any breakdowns. For example: A clinging power so he wouldn't have hard shoes or boots, a hidden wrist-shooter versus a web gun and holster, etc. ... I wasn't sure Stan would like the idea of covering the character's face but I did it because it hid an obviously boyish face. It would also add mystery to the character....",

				});*/
			films = new MyObservableCollection<FilmViewModel>(f);
			films.AddObs(new FilmViewModel(new Film(
				"Agora",
				"4544.jpg",
				12, 
				2009, 
				7.2, 
				new[] { "8", "4" },
				"A historical drama set in Roman Egypt, concerning a slave who turns to the rising tide of Christianity in the hope of pursuing freedom while falling in love with his mistress, the famous philosophy and mathematics professor Hypatia of Alexandria.")));
			SelectedFilm = films[0];
		}

		public FilmViewModel SelectedFilm
		{
			get => selectedFilm;
			set
			{
				selectedFilm = value;
				OnPropertyChanged();
			}
		}

		public MyObservableCollection<FilmViewModel> Films
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
