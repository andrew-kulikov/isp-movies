using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Movies.DataAcsessLayer
{
	public class CollectionReader
	{
		private FilmModel[] films;

		public CollectionReader()
		{
			Films = new FilmModel[0];
		}

		public static FilmModel[] Read()
		{
			throw new NotImplementedException();
		}

		public static void Write(FilmModel[] films)
		{

		}

		public FilmModel[] Films { get => films; set => films = value; }
	}
}
