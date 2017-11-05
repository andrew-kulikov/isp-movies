using Movies.BusinessLogic.Collections;
using Movies.DataAcsessLayer;

namespace Movies.BusinessLogic.Tools
{
	public static class Helper
	{
		public static void SerializeCollection(MyCollection<Film> films, string path)
		{
			MyCollection<FilmModel> models = new MyCollection<FilmModel>();
			foreach (var film in films)
			{
				if (film != null)
				{
					models.Add(film.ToDataModel());
				}
			}
			Accessor.WriteColl(models.ToArray(), path);
		}

		public static MyCollection<Film> DeserializeCollection(string path)
		{
			MyCollection<Film> films = new MyCollection<Film>();
			MyCollection<FilmModel> models = new MyCollection<FilmModel>(Accessor.ReadColl());
			foreach (var model in models)
			{
				Film f = new Film();
				f.Initialize(model);
				films.Add(f);
			}
			return films;
		}

		public static void ConnectCollections(
			ref MyCollection<Film> films,
			ref MyCollection<Actor> actors, 
			ref MyCollection<Producer> prods)
		{
			foreach (var film in films)
			{
				foreach (var actor in film.Actors)
				{
					bool res = false;
					foreach (var actorFilm in actor.Films)
					{
						if (actorFilm.Name == film.Name)
						{
							res = true;
							break;
						}
					}
					if (res == false)
					{
						actor.Films.Add(film);
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
						prod.Films.Add(film);
					}
				}
			}
		}
	}
}
