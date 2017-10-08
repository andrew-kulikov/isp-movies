using Movies.BusinessLogic.Collections;
using System;

namespace Movies.BusinessLogic
{
	public class Film
	{
		private string name;
		private string[] genres;
		private int ageLimit;
		private string description;
		private int yearOfRelease;
		private MyCollection<Actor> actors = null;
		private double rating;
		private Producer prod;

		public Film()
		{
			actors = new MyCollection<Actor>();
			prod = new Producer();
		}

		public Film(
			string name,
			int ageLimit, 
			int yearOfRelease, 
			double rating, 
			string[] genres, 
			string description)
		{
			this.name = name;
			this.ageLimit = ageLimit;
			this.yearOfRelease = yearOfRelease;
			this.genres = new string[genres.Length];
			this.rating = rating;
			this.description = description;
			Array.Copy(genres, this.genres, genres.Length);
		}

		public string Name
		{
			get => name;
			set => name = value;
		}

		public int AgeLimit
		{
			get => ageLimit;
			set
			{
				if (value >= 0 && value <= 21)
				{
					ageLimit = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Age limit is out of range");
				}
			}
		}
		public int YearOfRelease
		{
			get => yearOfRelease;
			set
			{
				if (value >= 1895 && value <= DateTime.Now.Year + 5)
				{
					yearOfRelease = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Year is out of range");
				}
			}
		}
		public string[] Genres
		{
			get => genres?.Clone() as string[];
			set => Array.Copy(genres, value, value.Length);

		}
		public string Description
		{
			get => description;
			set => description = value;
		}
		public double Rating
		{
			get => rating;
			set
			{
				if (value >= 0 && value <= 10)
				{
					rating = value;
				}
				else
				{
					throw new ArgumentOutOfRangeException("Rating is out of range");
				}
			}
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

		public void AddActor(Actor actor) => actors.Add(actor);
		public bool ContainsActor(Actor actor) => actors.Contains(actor);
		public override string ToString()
		{
			string res;
			res = "Name: " + name + "\nLimit: " + ageLimit + "\nYear: " + yearOfRelease + "\n";
			res += "Genres: ";
			foreach (string genre in genres)
			{
				res += genre + ", ";
			}
			return res;
		}
	}
}
