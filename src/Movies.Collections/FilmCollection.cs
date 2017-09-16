using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Movies.Collections
{
	class FilmCollection : IEnumerable<Film>
	{
		Film[] FilmArray = null;
		int count;
		public int Count => count;
		public FilmCollection(Film[] films)
		{
			count = films.Length;
			FilmArray = new Film[count];
			Array.Copy(films, FilmArray, films.Length);
		}

		public void Add(Film film)
		{
			if (++count > FilmArray.Length)
				Array.Resize(ref FilmArray, FilmArray.Length << 1);
			FilmArray[count] = film;
		}

		public IEnumerator<Film> GetEnumerator() => new FilmEnumerator(this);
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		class FilmEnumerator : IEnumerator<Film>
		{
			private readonly FilmCollection _this;
			public FilmEnumerator(FilmCollection collection)
			{
				_this = collection;
			}
			int position = -1;
			public bool MoveNext()
			{
				if (position < _this.FilmArray.Length - 1)
				{
					position++;
					return true;
				}
				else
				{
					return false;
				}
			}
			public Film Current => _this.FilmArray[position];
			object IEnumerator.Current => Current;
			public void Reset() => position = -1;
			public void Dispose() { }
		}

		public IEnumerable<Actor> EnumerateAuthors()
		{
			HashSet<Actor> hs = new HashSet<Actor>();
			for (int i = 0; i < FilmArray.Length; ++i)
			{
				for (int j = 0; j < FilmArray[i].Actors?.Count; j++)
				{
					hs.Add(FilmArray[i].Actors[j]);
				}
			}
			foreach (var actor in hs)
			{
				yield return actor;
			}
		}
	}
}
