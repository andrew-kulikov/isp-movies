using System.Collections;
using System.Collections.Generic;

namespace Movies.BusinessLogic.Collections
{
	internal class MyEnumerator<T> : IEnumerator<T>
	{
		private readonly MyCollection<T> sourceCollection;
		private int position = -1;

		public MyEnumerator(MyCollection<T> collection)
		{
			sourceCollection = collection;
		}

		public T Current => sourceCollection.ElementAt(position);
		object IEnumerator.Current => Current;

		public void Dispose() { }

		public bool MoveNext()
		{
			if (position < sourceCollection.Count - 1)
			{
				position++;
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Reset() => position = -1;
	}
}
