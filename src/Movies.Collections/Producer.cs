using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Collections
{
	public class Producer : IComparable
	{
		string name;
		MyCollection<Film> films;

		public Producer(string name, Film[] films)
		{
			this.name = name;
			this.films = new MyCollection<Film>(films);
		}

		public Film[] Films => films.ToArray();
		public string Name
		{
			get => name;
			set => name = value ?? throw new ArgumentNullException();
		}

		public int CompareTo(object obj)
		{
			Producer prod = obj as Producer;
			if (prod.Equals(null)) throw new Exception("dsjhfgjdfhg0");
			return name.CompareTo(prod.name);
		}
	}
}
