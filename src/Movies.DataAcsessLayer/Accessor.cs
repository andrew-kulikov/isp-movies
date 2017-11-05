using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace Movies.DataAcsessLayer
{
	public class Accessor
	{
		private static FileInfo file;
		private static StreamReader reader;
		private static string path = @"D:\git\isp-movies\src\Data\films.json";
		public Accessor(string path)
		{
			file = new FileInfo(path);
		}
		public static void Write(FilmModel film, string path)
		{

			if (Accessor.path == null || Accessor.path == "")
			{
				//here will be ecxeption
				Accessor.path = @"D:\git\isp-movies\src\Data\films.json";
				file = new FileInfo(Accessor.path);
			}
			file = new FileInfo(path);
			string json = JsonConvert.SerializeObject(film);

			using (StreamWriter sw = file.AppendText())
			{
				sw.WriteLine(json);
			}
		}
		public static FilmModel Read()
		{
			if (reader == null)
			{
				file = new FileInfo(path);
				reader = file.OpenText();
			}
			string json = reader.ReadLine();
			if (json != null)
			{
				FilmModel film = JsonConvert.DeserializeObject<FilmModel>(json);
				return film;
			}
			else
			{
				return null;
			}
		}
		public static void WriteColl(FilmModel[] films, string path)
		{
			if (Accessor.path == null || Accessor.path == "")
			{
				//here will be ecxeption
				Accessor.path = @"D:\git\isp-movies\src\Data\films.json";
				file = new FileInfo(Accessor.path);
			}
			file = new FileInfo(path);
			/*open file and check for existing items. if there is just one film, we add it to the 
			 collection, othrwise if file contains collection, we union them in one array and
			 serialize it into the file*/
			using (var reader1 = file.OpenText())
			{
				string cur = reader1.ReadLine();
				if (cur != null && cur != "")
				{
					try
					{
						FilmModel film = JsonConvert.DeserializeObject<FilmModel>(cur);
						if (film != null)
						{
							Array.Resize(ref films, films.Length + 1);
							films[films.Length - 1] = film;
							file.Delete();
						}
					}
					catch (Exception e)
					{
						Debug.Print(e.Message);
					}
					try
					{
						FilmModel[] films1 = JsonConvert.DeserializeObject<FilmModel[]>(cur);
						if (films1 != null)
						{
							HashSet<FilmModel> hs = new HashSet<FilmModel>(films1);
							hs.UnionWith(films);
							films = hs.ToArray();
						}
					}
					catch (Exception e)
					{
						Debug.Print(e.Message);
					}
				}
			}
			string json = JsonConvert.SerializeObject(films);
			if (reader != null)
			{
				reader.Close();
			}
			using (StreamWriter sw = new StreamWriter(path))
			{
				sw.WriteLine(json);
			}
		}
		public static FilmModel[] ReadColl()
		{
			if (reader == null)
			{
				file = new FileInfo(path);
				reader = file.OpenText();
			}
			reader = file.OpenText();
			string json = reader.ReadLine();
			if (json != null)
			{
				FilmModel[] films = JsonConvert.DeserializeObject<FilmModel[]>(json);
				return films;
			}
			else
			{
				return null;
			}
		}
	}
}
