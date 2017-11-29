﻿using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using Movies.BusinessLogic.Tools;
using Movies.UI.Model;
using Movies.UI.View;
using Movies.UI.ViewModel.Collections;
using Movies.UI.Tools;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace Movies.UI.ViewModel
{
	public class ApplicationViewModel : INotifyPropertyChanged
	{
		private MyObservableCollection<FilmViewModel> allFilms;
		private MyObservableCollection<FilmViewModel> films;
		private MyObservableCollection<ActorViewModel> actors;
		private MyObservableCollection<ActorViewModel> allActors;
		private MyObservableCollection<ActorViewModel> availableActors;
		private MyObservableCollection<ProducerViewModel> allProducers;
		private MyObservableCollection<ProducerViewModel> producers;
		private MyObservableCollection<FilmViewModel> nextPage;
		private MyObservableCollection<FilmViewModel> prevPage;
		private MyObservableCollection<FilmViewModel> curPage;
		private FilmViewModel selectedFilm;
		private ActorViewModel newActor;
		private ActorViewModel selectedActor;
		private ActorViewModel selectedAvailableActor;
		private ProducerViewModel selectedProducer;
		private ProducerViewModel newProducer;
		private RelayCommand addCommand;
		private RelayCommand addExistingActorCommand;
		private RelayCommand addNewActorCommand;
		private RelayCommand addNewProducerCommand;
		private RelayCommand addExistingProducerCommand;
		private RelayCommand removeCommand;
		private RelayCommand saveCommand;
		private RelayCommand openCommand;
		private RelayCommand loadCommand;
		private RelayCommand removePluginCommand;
		private RelayCommand queryCommand;
		private RelayCommand clearCommand;
		private RelayCommand groupCommand;
		private RelayCommand nextPageCommand;
		private RelayCommand prevPageCommand;
		private string tmpFilmName = "";
		private FilmViewModel newFilm;
		private Context context;
		private MyObservableCollection<IPlugin.IPlugin> plugins;
		private static IPlugin.IPlugin selectedPlugin;
		private double startRating = 0;
		private double endRating = 10;
		private double startAge = 0;
		private double endAge = 22;
		private bool nameUp;
		private bool nameDown;
		private bool ratingUp;
		private bool ratingDown;
		private int curPageNumber = 0;
		private int pageSize = 4;
		private Dictionary<string, bool> genres = new Dictionary<string, bool>();


		public ApplicationViewModel()
		{
			context = Context.Films;
			newActor = new ActorViewModel();
			films = new MyObservableCollection<FilmViewModel>();
			actors = new MyObservableCollection<ActorViewModel>();
			producers = new MyObservableCollection<ProducerViewModel>();
			newFilm = new FilmViewModel();
			AvailableActors = new MyObservableCollection<ActorViewModel>(Actors);
			NewProducer = new ProducerViewModel();
			allFilms = new MyObservableCollection<FilmViewModel>();
			allActors = new MyObservableCollection<ActorViewModel>();
			allProducers = new MyObservableCollection<ProducerViewModel>();
			LoadFromFile("films.json");
			try
			{
				selectedFilm = films[0];
			}
			catch
			{
				SelectedFilm = null;
			}
			LoadNextPage();
			LoadPluginsAsync(@"D:\git\isp-movies\src\plugins");
		}
		public FilmViewModel SelectedFilm
		{
			get => selectedFilm;
			set
			{
				context = Context.Films;
				selectedFilm = value;
				OnPropertyChanged();
			}
		}
		public string TmpFilmName
		{
			get => tmpFilmName;
			set
			{
				Restore();
				tmpFilmName = value;
				Filter();
				OnPropertyChanged();
			}
		}
		public bool NameUp
		{
			get => nameUp;
			set
			{
				nameUp = value;
				ratingDown = false;
				OnPropertyChanged("RatingUp");
				ratingUp = false;
				OnPropertyChanged("RatingDown");
				OnPropertyChanged();
			}
		}
		public bool NameDown
		{
			get => nameDown;
			set
			{
				nameDown = value;
				ratingDown = false;
				OnPropertyChanged("RatingUp");
				ratingUp = false;
				OnPropertyChanged("RatingDown");
				OnPropertyChanged();
			}
		}
		public bool RatingUp
		{
			get => ratingUp;
			set
			{
				ratingUp = value;
				nameDown = false;
				OnPropertyChanged("NameUp");
				nameUp = false;
				OnPropertyChanged("NameDown");
				OnPropertyChanged();
			}
		}
		public bool RatingDown
		{
			get => ratingDown;
			set
			{
				ratingDown = value;
				nameDown = false;
				OnPropertyChanged("NameUp");
				nameUp = false;
				OnPropertyChanged("NameDown");
				OnPropertyChanged();
			}
		}
		public Dictionary<string, bool> Genres
		{
			get => genres;
			set
			{
				genres = value;
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
		private string GetFileName()
		{
			OpenFileDialog od = new OpenFileDialog();
			od.Filter = "Json|*.json|Binary|*.dat|Archive|*.gz";
			if (od.ShowDialog() == DialogResult.OK)
			{
				return od.FileName;
			}
			return null;
		}
		private void Restore()
		{
			Films = new MyObservableCollection<FilmViewModel>(allFilms);
			Actors = new MyObservableCollection<ActorViewModel>(allActors);
			Producers = new MyObservableCollection<ProducerViewModel>(allProducers);
		}
		public void Filter()
		{
			if (context == Context.Films)
			{
				var newFilms = from film in allFilms
							   where film.Rating <= endRating && film.Rating >= startRating
							   && film.AgeLimit >= startAge && film.AgeLimit <= endAge
							   select film;
				if (genres.Count != 0 && !genres.All(x => !x.Value))
				{
					newFilms = from film in newFilms
							   from genre in genres.Keys
							   where genres[genre] && film.Genres.Contains(genre)
							   select film;
				}
				var newFilms1 = new HashSet<FilmViewModel>(newFilms);
				newFilms = newFilms1.AsEnumerable();
				if (nameUp)
				{
					newFilms = from film in newFilms
							   orderby film.Name
							   select film;
				}
				else if (nameDown)
				{
					newFilms = from film in newFilms
							   orderby film.Name descending
							   select film;
				}
				if (ratingUp)
				{
					newFilms = from film in newFilms
							   orderby film.Rating
							   select film;
				}
				else if (ratingDown)
				{
					newFilms = from film in newFilms
							   orderby film.Rating descending
							   select film;
				}
				films = new MyObservableCollection<FilmViewModel>(newFilms.ToArray());
				Films.Refresh();
				
				Films.Refresh();
				CurPage = new MyObservableCollection<FilmViewModel>(films.Take(pageSize).ToArray());
				try
				{
					SelectedFilm = curPage[0];
				}
				catch
				{
					SelectedFilm = null;
				}
				LoadNextPage();
			}
			else if (context == Context.Actors)
			{
				Actors.Refresh();  
			}
			else if (context == Context.Prodecers)
			{
				Producers.Refresh();
			}
			Find();
			
		}
		private void LoadFromFile(string path)
		{
			string fileName = "films.json";
			if (path != null)
			{
				fileName = path;

				int mode = 0;
				MyCollection<Film> newFilms = new MyCollection<Film>();
				if (Path.GetExtension(fileName) == ".dat")
				{
					mode = 1;
				}
				else if (Path.GetExtension(fileName) == ".gz")
				{
					mode = 2;
				}
				newFilms = Helper.DeserializeCollection(fileName, mode);

				foreach (var film in newFilms)
				{
					if (film != null)
					{
						FilmViewModel film1 = new FilmViewModel(film);
						MyCollectionsConverter.AddFilm(film1, ref allActors, ref allProducers);
						allFilms.AddObs(film1);
					}
				}

				foreach (var film in allFilms)
				{

					MyCollection<Film> fullColl = new MyCollection<Film>();
					foreach (var f in allFilms)
					{
						fullColl.Add(f.Source);
					}
					film.SetActorFilms(fullColl);
					foreach (var actor in film.Actors)
					{
						allActors.AddObs(actor);
					}
				}
				MyCollectionsConverter.ConnectCollection(ref allFilms, ref allActors, ref allProducers);
				Films.Refresh();
				allActors.Refresh();
				allProducers.Refresh();
				Producers = new MyObservableCollection<ProducerViewModel>(allProducers);
				Actors = new MyObservableCollection<ActorViewModel>(allActors);
				Filter();
			}
		}
		public bool Find()
		{
			bool res = false;
			if (context == Context.Films)
			{
				var newFilms = from film in films
							   where film.Name.ToLower().Contains(tmpFilmName.ToLower())
							   select film;
				Films = new MyObservableCollection<FilmViewModel>(newFilms.ToArray());
				try
				{
					SelectedFilm = films[0];
				}
				catch
				{
					SelectedFilm = null;
				}
			}
			else if (context == Context.Actors)
			{
				var newActors = from actor in actors
							   where actor.FullName.ToLower().Contains(tmpFilmName.ToLower())
							   select actor;
				Actors = new MyObservableCollection<ActorViewModel>(newActors.ToArray());
				try
				{
					SelectedActor = actors[0];
				}
				catch
				{
					SelectedActor = null;
				}
			}
			else if (context == Context.Prodecers)
			{
				var newProds = from prod in producers
								where prod.FullName.ToLower().Contains(tmpFilmName.ToLower())
								select prod;
				Producers = new MyObservableCollection<ProducerViewModel>(newProds.ToArray());
				try
				{
					SelectedProducer = producers[0];
				}
				catch
				{
					SelectedProducer = null;
				}
			}

			return res;
		}
		private bool FindActor(string fullName)
		{
			foreach (ActorViewModel actor in newFilm.Actors)
			{
				if (actor.FullName == fullName)
				{
					return true;
				}
			}
			return false;
		}
		private bool FindProducer(string fullName)
		{
			if (newFilm.Prod != null &&
				newFilm.ProducerName != "" &&
				newFilm.ProducerName == fullName)
			{
				return true;
			}
			return false;
		}
		public double StartRating
		{
			get => startRating;
			set
			{
				startRating = value;
				OnPropertyChanged();
			}
		}
		public double EndRating
		{
			get => endRating;
			set
			{
				endRating = value;
				OnPropertyChanged();
			}
		}
		public double StartAge
		{
			get => startAge;
			set
			{
				startAge = value;
				OnPropertyChanged();
			}
		}
		public double EndAge
		{
			get => endAge;
			set
			{
				endAge = value;
				OnPropertyChanged();
			}
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
		public ActorViewModel SelectedActor
		{
			get => selectedActor;
			set
			{
				context = Context.Actors;
				selectedActor = value;
				OnPropertyChanged();
			}
		}
		public MyObservableCollection<FilmViewModel> CurPage
		{
			get => curPage;
			set
			{
				curPage = value;
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
		public Context Context
		{
			get => context;
			set
			{
				context = value;
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
				OnPropertyChanged();
			}
		}
		public MyObservableCollection<ProducerViewModel> Producers
		{
			get => producers;
			set
			{
				producers = value;
				OnPropertyChanged();
			}
		}
		public ProducerViewModel NewProducer
		{
			get => newProducer;
			set
			{
				newProducer = value;
				OnPropertyChanged();
			}
		}
		public ProducerViewModel SelectedProducer
		{
			get => selectedProducer;
			set
			{
				context = Context.Prodecers;
				selectedProducer = value;
				OnPropertyChanged();
			}
		}
		public RelayCommand AddNewActorCommand => addNewActorCommand ?? (addNewActorCommand =
			new RelayCommand(obj =>
			{
				if (newActor.IsReady && FindActor(newActor.FullName) == false)
				{
					newActor.Films.Add(newFilm.Source);
					newFilm.AddActor(newActor);
					allActors.AddObs(newActor);
					NewActor = new ActorViewModel();
					System.Windows.MessageBox.Show("Actor successfully added!");
				}
				else if (!newActor.IsReady)
				{
					System.Windows.MessageBox.Show("Enter correct information!");

				}
				else if (FindActor(newActor.FullName) == false)
				{
					System.Windows.MessageBox.Show("Actor already exists!");
				}
			}));
		public RelayCommand AddExistingActorCommand => addExistingActorCommand ?? (addExistingActorCommand =
			new RelayCommand(obj =>
			{
				if (selectedAvailableActor != null &&
				selectedAvailableActor.Name != "" &&
				FindActor(selectedAvailableActor.FullName) == false)
				{
					newFilm.Actors.AddObs(selectedAvailableActor);
					AvailableActors.RemoveObs(selectedAvailableActor.FullName);
				}
			}));
		public RelayCommand AddFilmCommand => addCommand ?? (addCommand =
			new RelayCommand(obj =>
			{
				if (NewFilm.IsReady())
				{
					NewFilm.TransformGenres();
					NewFilm.Actors = newFilm.Actors;
					/*foreach (var actor in newFilm?.Actors)
					{
						actor.Films.Add(newFilm.Source);
					}*/

					//Films.AddObs(NewFilm);
					allFilms.AddObs(NewFilm);

					NewFilm = new FilmViewModel();
					availableActors = new MyObservableCollection<ActorViewModel>(allActors);
					SelectedAvailableActor = new ActorViewModel();
					AvailableActors.Refresh();
					Filter();
					OnPropertyChanged("AvailableActors");
				}
				else
				{
					System.Windows.MessageBox.Show("Enter correct information!");
				}
			}));
		public RelayCommand AddExistingProducerCommand => addExistingProducerCommand ??
			(addExistingProducerCommand = new RelayCommand(obj =>
			{
				if ((newFilm.Prod == null || newFilm.Prod.Name == null || newFilm.Name == "") &&
					selectedProducer != null &&
					selectedProducer.Name != "" &&
					FindProducer(selectedProducer.FullName) == false)
				{
					//!
					selectedProducer.Films.Add(newFilm.Source);
					newFilm.Prod = selectedProducer.Source;
				}
			}));
		public RelayCommand AddNewProducerCommand => addNewProducerCommand ??
		   (addNewProducerCommand = new RelayCommand(obj =>
		   {
			   if (newFilm.Prod == null || newFilm.Prod.Name == null || newFilm.Prod.Name == "")
			   {
				   NewProducer.Films.Add(NewFilm.Source);
				   NewFilm.Prod = NewProducer.Source;
				   Producers.AddObs(NewProducer);
				   NewProducer = new ProducerViewModel();
			   }
		   }));
		public RelayCommand RemoveCommand => removeCommand ??
			(removeCommand = new RelayCommand(obj =>
			{
				if (context == Context.Films)
				{
					if (allFilms.Count != 0)
					{
						MyCollectionsConverter.DeleteFilm(selectedFilm?.Name, ref actors, ref producers);
						bool res = allFilms.RemoveObs(selectedFilm?.Name);
						if (allFilms.Count != 0)
						{
							SelectedFilm = films[0];
						}
						else
						{
							SelectedFilm = null;
						}
					}
				}
				else if (context == Context.Actors)
				{
					if (actors.Count != 0)
					{
						string name = selectedActor?.FullName;

						bool res = Actors.RemoveObs(name);
						foreach (var film in allFilms)
						{
							film.RemoveActor(name);
						}
						//films = MyCollectionsConverter.DeleteActor(name, films);
						if (actors.Count != 0)
						{
							SelectedActor = actors[0];
						}
						else
						{
							SelectedActor = null;
						}
					}
				}
				else if (context == Context.Prodecers)
				{
					if (producers.Count != 0)
					{
						string name = selectedProducer?.FullName;
						bool res = Producers.RemoveObs(name);
						MyCollectionsConverter.DeleteProduer(name, ref allFilms);
						if (producers.Count != 0)
						{
							SelectedProducer = producers[0];
						}
						else
						{
							SelectedProducer = null;
						}
					}
				}
				Filter();
				OnPropertyChanged("Films");
			}));
		public RelayCommand SaveCommand => saveCommand ??
			(saveCommand = new RelayCommand(obj =>
			{
				string fileName;
				SaveFileDialog sd = new SaveFileDialog();
				sd.Filter = "Json|*.json|Binary|*.dat|Archive|*.gz";
				if (sd.ShowDialog() == DialogResult.OK)
				{
					fileName = sd.FileName;

					int mode = 0;
					if (sd.FilterIndex == 3)
					{
						mode = 2;
						fileName = fileName.Replace(".gz", ".json");
					}
					else if (sd.FilterIndex == 2)
					{
						mode = 1;
					}
					MyCollection<Film> allFims = new MyCollection<Film>();
					foreach (var f in films)
					{
						allFims.Add(f.Source);
					}
					Helper.SerializeCollection(allFims, fileName, mode);
				}
			}));
		public RelayCommand OpenCommand => openCommand ??
			(openCommand = new RelayCommand(obj =>
			{
				string path = GetFileName();
				LoadFromFile(path);
			}));
		public RelayCommand LoadCommand => loadCommand ??
			(loadCommand = new RelayCommand(obj =>
			{
				Plugins p = new Plugins(this);
				p.ShowDialog();
			}));
		public RelayCommand ClearCommand => clearCommand ??
			(clearCommand = new RelayCommand(obj =>
			{
				StartAge = 0;
				EndAge = 22;
				StartRating = 0;
				EndRating = 10;
				NameUp = false;
				NameDown = false;
				RatingUp = false;
				RatingDown = false;
				Genres = new Dictionary<string, bool>();
				Actors = new MyObservableCollection<ActorViewModel>(allActors);
				Films = new MyObservableCollection<FilmViewModel>(allFilms);
				Producers = new MyObservableCollection<ProducerViewModel>(allProducers);
				TmpFilmName = "";
			}));
		public RelayCommand QueryCommand => queryCommand ??
			(queryCommand = new RelayCommand(obj =>
			{
				Filter();
			}));
		public RelayCommand GroupCommand => groupCommand ??
			(groupCommand = new RelayCommand(obj =>
			{
				var newActors = from actor in allActors
								group actor by actor.Films.Count;
				string res = "";
				foreach (var g in newActors)
				{
					res += "Amount of films: " + g.Key + "\n";
					foreach (var actor in g)
					{
						res += actor.FullName + ", ";
					}
					res += "\n";
				}
				System.Windows.MessageBox.Show(res);
			}
			));
		public static IPlugin.IPlugin SelectedPluginForFilm => selectedPlugin;
		public IPlugin.IPlugin SelectedPlugin
		{
			get => selectedPlugin;
			set
			{
				CurPage.Refresh();
				selectedPlugin = value;
				OnPropertyChanged("HeaderColor");
				System.Windows.MessageBox.Show("Plugin " + selectedPlugin.Name + " added!");
				OnPropertyChanged();
			}
		}
		public MyObservableCollection<IPlugin.IPlugin> Plugins
		{
			get => plugins;
			set
			{
				plugins = value;
				OnPropertyChanged();
			}
		}
		public RelayCommand RemovePluginCommand => removePluginCommand ??
			(removePluginCommand = new RelayCommand(obj =>
			{
				selectedPlugin = null;
				OnPropertyChanged("HeaderColor");
				Films.Refresh();
			}));
		public void LoadPlugins(string path)
		{
			string[] dllFileNames = null;

			if (Directory.Exists(path))
			{
				dllFileNames = Directory.GetFileSystemEntries(path, "*.dll");

				MyCollection<Assembly> assemblies = new MyCollection<Assembly>();
				foreach (string dllFile in dllFileNames)
				{
					AssemblyName an = AssemblyName.GetAssemblyName(dllFile);
					Assembly assembly = Assembly.Load(an);
					assemblies.Add(assembly);
				}

				Type pluginType = typeof(IPlugin.IPlugin);
				MyCollection<Type> pluginTypes = new MyCollection<Type>();
				foreach (Assembly assembly in assemblies)
				{
					if (assembly != null)
					{
						Type[] types = assembly.GetTypes();

						foreach (Type type in types)
						{
							if (type.IsInterface || type.IsAbstract)
							{
								continue;
							}
							else
							{
								if (type.GetInterface(pluginType.FullName) != null)
								{
									pluginTypes.Add(type);
								}
							}
						}
					}
				}

				Plugins = new MyObservableCollection<IPlugin.IPlugin>();
				foreach (Type type in pluginTypes)
				{
					Thread.Sleep(5000);
					IPlugin.IPlugin plugin = (IPlugin.IPlugin)Activator.CreateInstance(type);
					System.Windows.Application.Current.Dispatcher.InvokeAsync(() => Plugins.AddObs(plugin));
				}
			}
		}
		public string HeaderColor => selectedPlugin?.HeaderColor;
		public void LoadPluginsAsync(string path)
		{
			//Thread t = new Thread(new ParameterizedThreadStart(LoadPlugins));
			//t.Start(path);
			Task loadPluginsTask = Task.Run(() => LoadPlugins(path));
		}
		public void LoadNextPage()
		{
			Task t = Task.Factory.StartNew(() =>
			{
				nextPage = new MyObservableCollection<FilmViewModel>(films.Skip((curPageNumber + 1) * pageSize).Take(pageSize).ToArray());
				if (nextPage == null)
				{
					curPageNumber--;
				}
			});
		}
		public void LoadPrevPage()
		{
			Task t = Task.Factory.StartNew(() =>
			{
				if (curPageNumber <= 0)
				{
					curPageNumber = 0;
					return;
				}
				prevPage = new MyObservableCollection<FilmViewModel>(films.Skip((curPageNumber - 1) * pageSize).Take(pageSize).ToArray());
			});
		}
		public RelayCommand NextPageCommand => nextPageCommand ?? (
			nextPageCommand = new RelayCommand(obj =>
			{
				curPageNumber++;
				CurPage = new MyObservableCollection<FilmViewModel>(nextPage);
				try
				{
					SelectedFilm = curPage[0];
				}
				catch
				{
					SelectedFilm = null;
				}
				LoadNextPage();
				LoadPrevPage();
			}));
		public RelayCommand PrevPageCommand => prevPageCommand ?? (
			prevPageCommand = new RelayCommand(obj =>
			{
				curPageNumber--;
				CurPage = new MyObservableCollection<FilmViewModel>(prevPage);
				try
				{
					SelectedFilm = curPage[0];
				}
				catch
				{
					SelectedFilm = null;
				}
				LoadNextPage();
				LoadPrevPage();
			}));

		public string IconPath => Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "Images", "logo.png");

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
