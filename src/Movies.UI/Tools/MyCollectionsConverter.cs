using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.BusinessLogic.Collections;
using Movies.BusinessLogic.Tools;
using Movies.BusinessLogic;
using Movies.UI.ViewModel;
using Movies.UI.ViewModel.Collections;

namespace Movies.UI.Tools
{
	public static class MyCollectionsConverter
	{
		public static MyCollection<Film> ObsToReg(MyObservableCollection<FilmViewModel> coll)
		{
			MyCollection<Film> newColl = new MyCollection<Film>();
			foreach (var filmViewModel in coll)
			{
				newColl.Add(filmViewModel.Source);
			}
			return newColl;
		}
		public static MyCollection<Actor> ObsToReg(MyObservableCollection<ActorViewModel> coll)
		{
			MyCollection<Actor> newColl = new MyCollection<Actor>();
			foreach (var actorViewModel in coll)
			{
				newColl.Add(actorViewModel.SourceActor);
			}
			return newColl;
		}
		public static MyCollection<Producer> ObsToReg(MyObservableCollection<ProducerViewModel> coll)
		{
			MyCollection<Producer> newColl = new MyCollection<Producer>();
			foreach (var prodViewModel in coll)
			{
				newColl.Add(prodViewModel.Source);
			}
			return newColl;
		}
		public static void DeleteFilm(
			string filmName,
			ref MyObservableCollection<ActorViewModel> actors,
			ref MyObservableCollection<ProducerViewModel> producers)
		{
			for (int i = 0; i < actors?.Count; i++)
			{
				for (int j = 0; j < actors[i]?.Films?.Count; j++)
				{
					if (actors[i].Films[j].Name == filmName)
					{
						actors[i].Films.Remove(actors[i].Films[j]);
					}
				}
			}
			for (int i = 0; i < producers?.Count; i++)
			{
				for (int j = 0; j < producers[i].Films?.Count; j++)
				{
					if (producers[i].Films[j].Name == filmName)
					{
						producers[i].Films.Remove(producers[i].Films[j]);
					}
				}
			}
		}
		public static void AddFilm(
			FilmViewModel film,
			ref MyObservableCollection<ActorViewModel> actors,
			ref MyObservableCollection<ProducerViewModel> producers)
		{
			foreach (var actor in film?.Actors)
			{
				bool res = false;
				foreach (var act in actors)
				{
					if (act.FullName == actor.FullName)
					{
						res = true;
					}
				}
				if (!res)
				{
					actors.Add(actor);
				}
			}
			var prod = film.Prod;
			bool res1 = false;
			foreach (var producer in producers)
			{
				if (producer.Name == prod.Name)
				{
					res1 = true;
				}
			}
			if (!res1)
			{
				producers.Add(new ProducerViewModel(prod));
			}

		}
		public static MyObservableCollection<FilmViewModel> DeleteActor(string fullName, MyObservableCollection<FilmViewModel> films)
		{
			foreach (var film in films)
			{
				foreach (var actor in film.Actors)
				{
					if (actor.FullName == fullName)
					{
						film.SelectedActor = null;
						film.Actors.Remove(actor);
					}
				}
			}
			return films;
		}
		public static void DeleteProduer(string name, ref MyObservableCollection<FilmViewModel> films)
		{
			foreach (var film in films)
			{
				if (film.Prod.Name + " " + film.Prod.Surname == name)
				{
					film.Prod = new Producer();
				}
			}
		}
		public static void ConnectCollection(
			ref MyObservableCollection<FilmViewModel> films,
			ref MyObservableCollection<ActorViewModel> actors,
			ref MyObservableCollection<ProducerViewModel> prods)
		{
			foreach (var actor in actors)
			{
				foreach (var film in films)
				{
					if (actor.IsInFilm(film))
					{
						film.Actors.AddObs(actor);
					}
				}
			}
			foreach (var film in films)
			{
				foreach (var actor in film.Actors)
				{
					bool res = false;
					foreach (var act in actors)
					{
						if (act.FullName == actor.FullName)
						{
							res = true;
							break;
						}
					}
					if (res)
					{
						MyObservableCollection<FilmViewModel> newFilms = new MyObservableCollection<FilmViewModel>();
						foreach (var f in actor.Films)
						{
							newFilms.AddObs(new FilmViewModel(f));
						}
						newFilms.AddObs(film);
						actor.Films = ObsToReg(newFilms);
					}
				}
				foreach (var prod in prods)
				{
					bool res = false;
					foreach (var prodFilm in prod.Films)
					{
						if (prodFilm.Name == film.Name)
						{
							res = true;
							break;
						}
					}
					if (res == false)
					{
						prod.Films.Add(film.Source);
					}
				}
			}
			
		}

		public static List<double> GetRatings(MyObservableCollection<FilmViewModel> films)
		{
			return films.Select(x => x.Rating).ToList();
		}
	}
}
