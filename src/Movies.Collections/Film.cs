using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Collections
{
	public class Film : IComparable
	{
		#region Private_Fields
		private string name;
		private string posterPath;
		private string[] genres;
		private int ageLimit;
		private int yearOfRelease;
		private MyCollection<Actor> actors = null;
		private double rating;
		private Producer prod;
		#endregion

		public Film(string name, string posterPath, int ageLimit, int yearOfRelease, double rating, string[] genres)
		{
			this.name = name;
			this.posterPath = posterPath;
			this.ageLimit = ageLimit;
			this.yearOfRelease = yearOfRelease;
			this.genres = new string[genres.Length];
			this.rating = rating;
			Array.Copy(genres, this.genres, genres.Length);
		}

		#region Properties
		public string Name
		{
			get => name;
			set => name = value;
		}
		public string PosterPath
		{
			get => posterPath;
			set => posterPath = value;
		}
		public int AgeLimit
		{
			get => ageLimit;
			set => ageLimit = value;
		}
		public int YearOfRelease
		{
			get => yearOfRelease;
			set => yearOfRelease = value;
		}
		public string[] Genres
		{
			get => genres.Clone() as string[];
			set => Array.Copy(genres, value, value.Length);

		}
		public double Rating
		{
			get => rating;
			set => rating = value;
		}
		public MyCollection<Actor> Actors
		{
			get => actors;
			set => actors = value;
		}
		public Producer Prod
		{
			get => prod;
			set => prod = value;
		}
		#endregion

		public int CompareTo(object obj)
		{
			Film film = obj as Film;
			if (film.Equals(null)) throw new Exception("Wrong type");
			return name.CompareTo(film.name);
		}
		public void AddActor(Actor actor) => actors.Add(actor);
		public bool ContainsActor(Actor actor) => actors.Contains(actor);
		public override string ToString()
		{
			string res;
			res = "Name: " + name + "\nPoster: " + posterPath + "\nLimit: " + ageLimit + "\nYear: " + yearOfRelease + "\n";
			res += "Genres: ";
			foreach (string genre in genres)
			{
				res += genre + ", ";
			}
			return res;
		}
	}
}
