using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Collections
{
	public class MyCollection<T> : ICollection<T> where T: IComparable
	{
		#region Private_Fields
		private SortedSet<T> data;
		private int count;
		private class MyEnumerator : IEnumerator<T>
		{
			#region Private_Fields
			private readonly MyCollection<T> sourceCollection;
			private int position = -1;
			#endregion

			#region Constructors
			public MyEnumerator(MyCollection<T> collection)
			{
				sourceCollection = collection;
			}
			#endregion

			#region Properties

			public T Current => sourceCollection.ElementAt(position);
			object IEnumerator.Current => Current;

			#endregion

			#region Public_Methods
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
			#endregion
		}
		#endregion

		#region Constructors
		public MyCollection()
		{
			count = 0;
			data = new SortedSet<T>();
		}

		public MyCollection(params T[] items)
		{
			count = 0;
			data = new SortedSet<T>();
			Add(items);
		}
		#endregion

		#region Properties
		public int Count => count;

		public T this[int i] => data.ElementAt(i);

		public bool IsReadOnly => false;
		#endregion

		#region Public_Methods

		public void Add(T item)
		{
			if (!item.Equals(null) && !IsReadOnly)
			{
				if (data.Add(item))
					count++;
			}
		}

		public void Add(params T[] items)
		{
			if (items.Equals(null)) throw new ArgumentNullException();
			data.UnionWith(items);
			count = data.Count;
		}

		public void Add(MyCollection<T> coll)
		{
			data.UnionWith(coll);
			count = data.Count;
		}

		public void Clear() => data.Clear();

		public bool Contains(T item) => data.Contains(item);

		public void CopyTo(T[] array, int arrayIndex = 0)
		{
			if (arrayIndex + count > array.Length)
			{
				throw new OverflowException("Array overflow");
			}
			else
			{
				var items = data.ToArray();
				for (int i = arrayIndex; i < arrayIndex + count; i++)
				{
					array[i] = items[i - arrayIndex];
				}
			}
			
		}

		public T ElementAt(int pos) => data.ElementAt(pos);

		public IEnumerator<T> GetEnumerator() => new MyEnumerator(this);

		public bool Remove(T item)
		{
			if (data.Equals(null)) throw new Exception("Removing from empty collection");
			else
			{
				if(data.Remove(item))
				{
					count--;
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public IEnumerator<T> EnumerateAll()
		{
			for (int i = 0; i < count; i++)
			{
				yield return data.ElementAt(i);
			}
		}
		#endregion

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
