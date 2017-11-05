using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAcsessLayer
{
	public class FilmModel
	{
		private string name;
		private string genres;
		private int ageLimit;
		private string description;
		private int yearOfRelease;
		private ActorModel[] actors;
		private double rating;
		private ProducerModel prod;

		public FilmModel()
		{
			prod = new ProducerModel();
			actors = new ActorModel[0];
		}

		/*public FilmModel(
			string name, string genres, int ageLimit,
			string yearOfRelease, ActorModel[] actors, double rating, ProducerModel model)
		{
			this.name = name;
			this.genres = 
		}*/

		public string Name { get => name; set => name = value; }
		public string Genres { get => genres; set => genres = value; }
		public int AgeLimit { get => ageLimit; set => ageLimit = value; }
		public string Description { get => description; set => description = value; }
		public int YearOfRelease { get => yearOfRelease; set => yearOfRelease = value; }
		public ActorModel[] Actors { get => actors; set => actors = value; }
		public double Rating { get => rating; set => rating = value; }
		public ProducerModel Prod { get => prod; set => prod = value; }
	}
}
