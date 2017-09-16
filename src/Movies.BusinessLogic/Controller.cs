using Movies.BusinessLogic.Collections;

namespace Movies.BusinessLogic
{
	public class Controller
	{
		MyCollection<Film> films;
		MyCollection<Actor> actors;
		MyCollection<Producer> prods;
		public Controller(MyCollection<Film> films, MyCollection<Actor> actors, MyCollection<Producer> prods)
		{
			this.films = films;
			this.actors = actors;
			this.prods = prods;
		}
		public void AddActor(Actor actor)
		{
			actors.Add(actor);
			films.Add(actor.Films);
		}
		public void AddFilm(Film film)
		{
			films.Add(film);
			actors.Add(film.Actors);
			prods.Add(film.Prod);
		}
		public void AddProducer(Producer prod)
		{
			prods.Add(prod);
			films.Add(prod.Films);
		}
		public void RemoveActor(Actor actor)
		{
			actors.Remove(actor);
			foreach (Film film in films)
			{
				film?.Actors?.Remove(actor);
			}
		}
	}
}
