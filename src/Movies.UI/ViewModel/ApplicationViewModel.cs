using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using Movies.UI.ViewModel.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Movies.UI.ViewModel
{
	public class ApplicationViewModel : INotifyPropertyChanged
	{
		private MyObservableCollection<FilmViewModel> films;
		private MyObservableCollection<ActorViewModel> actors;
		private MyObservableCollection<ActorViewModel> availableActors;
		private FilmViewModel selectedFilm;
		private ActorViewModel newActor;
		private ActorViewModel selectedAvailableActor;

		private string tmpFilmName;

		private FilmViewModel newFilm;

		private Film Digimon, Noise, Agora; 

		public ApplicationViewModel()
		{
			newActor = new ActorViewModel();
			Digimon = new Film(
					"Digimon",
					18,
					2017,
					6.3,
					"1, 2, 3",
					"A group of young teens is unexpectedly sent to the mysterious Digital World and paired up with their own powerful, morphing monster called the Digimon. Together the entire group set out on an adventure to fight evil and save the world.");
			Noise = new Film(
					"White Noise 2",
					12,
					2007,
					5.7,
					"5, 2, 7",
					"Following the loss of his family, a man attempts suicide only to discover upon waking that he can identify people who are about to die");
			Agora = new Film(
				"Agora",
				12,
				2009,
				7.2,
				"8, 4",
				"A historical drama set in Roman Egypt, concerning a slave who turns to the rising tide of Christianity in the hope of pursuing freedom while falling in love with his mistress, the famous philosophy and mathematics professor Hypatia of Alexandria.");
	
			FilmViewModel[] f = new FilmViewModel[]
			{
				new FilmViewModel(Digimon),
				new FilmViewModel(Noise),
				new FilmViewModel(new Film(
					"Safety Not Guaranteed",
					12, 
					2012, 
					7.0, 
					"8, 4",
					"Three magazine employees head out on an assignment to interview a guy who placed a classified advertisement seeking a companion for time travel.")),
				new FilmViewModel(new Film(
					"Four brothers",
					21, 
					2005, 
					5.6, 
					"1, 2, 3",
					"Four adopted brothers come to avenge their mother's death in what appears to be a random killing in a grocery store robbery. However, the boys' investigation of the death reveals more nefarious activities involving the one brother's business dealings with a notorious local hoodlum. Two cops who are trying to solve the case may also not be what they seem."))
			};
			ActorViewModel Parker = new ActorViewModel(
						"Peter",
						"Parker",
						new System.DateTime(1956, 4, 24),
						"One of the first things I did was to work up a costume.",
						new MyCollection<Film>(Agora, Digimon));
			ActorViewModel Brat = new ActorViewModel(
					"Brat",
					"The son of his father",
					new System.DateTime(1975, 7, 18),
					"One of the first things I did was to work up a costume.",
					new MyCollection<Film>(Noise, Agora));
			actors = new MyObservableCollection<ActorViewModel>(Parker, Brat);
			films = new MyObservableCollection<FilmViewModel>(f);
			foreach (FilmViewModel film in films)
			{
				film.Actors = actors;
			}
			films.AddObs(new FilmViewModel(Agora));
			SelectedFilm = films[0];
			newFilm = new FilmViewModel();
		}

		public FilmViewModel SelectedFilm
		{
			get => selectedFilm;
			set
			{
				selectedFilm = value;
				//selectedFilm.Actors = actors;
				Producer prod = new Producer("James", "Cameron", new System.DateTime(1964, 12, 14), new MyCollection<Film>(Noise, Digimon, Agora));
				selectedFilm.Prod = prod;
				OnPropertyChanged();
			}
		}

		public string TmpFilmName
		{
			get => tmpFilmName;
			set
			{
				tmpFilmName = value;
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

		public FilmViewModel NewFilm
		{
			get => newFilm;
			set
			{
				newFilm = value;
				OnPropertyChanged();
			}
		}

		public bool Remove()
		{
			if (selectedFilm?.Name == tmpFilmName)
			{
				selectedFilm = null;
				OnPropertyChanged("SelectedFilm");
			}
			bool res = Films.RemoveObs(tmpFilmName);
			OnPropertyChanged("Films");
			return res;
		}

		public bool Find()
		{
			bool res = false;
			foreach (FilmViewModel film in Films)
			{
				if (film?.Name == tmpFilmName)
				{
					SelectedFilm = film;
					res = true;
					break;
				}
			}
			return res;
		}

		public ActorViewModel NewActor
		{
			get => newActor;
			set
			{
				newActor = value;
				OnPropertyChanged();
			}
		}

		public MyObservableCollection<ActorViewModel> Actors
		{
			get => actors;
			set
			{
				actors = value;
				OnPropertyChanged();
			}
		}

		public MyObservableCollection<ActorViewModel> AvailableActors
		{
			get => availableActors;
			set
			{
				availableActors = value;
				OnPropertyChanged();
			}
		}

		public ActorViewModel SelectedAvailableActor
		{
			get => selectedAvailableActor;
			set
			{
				selectedAvailableActor = value;
				newFilm.Actors.Add(selectedAvailableActor);
				AvailableActors.RemoveObs(selectedAvailableActor.FullName);
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
