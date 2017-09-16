﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Collections
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Films:");
				MyCollection<Film> coll = new MyCollection<Film>();
				Film f1 = new Film("ZX", "1.jpg", 2, 3, 5.6, new[] { "E", "R", "T" });
				coll.Add(new Film("ZX", "1.jpg", 2, 3, 5.6, new[] { "E", "R", "T" }));
				coll.Add(new Film("ZZ", "2.jpg", 5, 6, 9.8, new[] { "G", "RER", "DFD" }));
				coll.Add(new Film("H", "3.jpg", 8, 9, 4.4, new[] { "FE", "EFEF", "EEFF" }));
				coll.Add(new Film("D", "4.jpg", 56, 43, 7.3, new[] { "EYBGG", "FFFR", "EF" }));
				foreach (Film t in coll)
				{
					Console.WriteLine(t);
					Console.WriteLine(new string('-', 30));
				}
				Console.WriteLine("Actors");
				MyCollection<Actor> actors = new MyCollection<Actor>();
				Actor peterParker = new Actor("Peter Parker", (9, 10, 2017), new[] { "dfdfs", "dsfds", "SDFf" }, coll);
				actors.Add(peterParker);
				actors.Add(new Actor("Peter Parker", (1, 2, 3), new[] { "dfdfs", "dsfds", "SDFf" }, coll));
				foreach (var actor in actors)
				{
					Console.WriteLine(actor);
					Console.WriteLine(new string('-', 30));
				}
				Controller controller = new Controller(coll, actors, new MyCollection<Producer>());
				controller.RemoveActor(peterParker);

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
