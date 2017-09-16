using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.BusinessLogic
{
	public class MyCollection<T> : ICollection<T>
	{
		private T[] data;
		private int count;

		public MyCollection()
		{
			count = 0;
			data = new T[0];
		}

		public MyCollection(params T[] items)
		{
			count = 0;
			data = new T[items.Length];
			Add(items);
		}

		public int Count => count;

		public T this[int i] => data.ElementAt(i);

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			throw new NotImplementedException();

			//if (!item.Equals(null) && !IsReadOnly)
			//{
			//	if (data.Add(item))
			//		count++;
			//}
		}

		public void Add(params T[] items)
		{
			throw new NotImplementedException();

			//if (items.Equals(null)) throw new ArgumentNullException();
			//data.UnionWith(items);
			//count = data.Count;
		}

		public void Add(MyCollection<T> coll)
		{
			throw new NotImplementedException();

			//data.UnionWith(coll);
			//count = data.Count;
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

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

		public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(this);

		public bool Remove(T item)
		{
			throw new NotImplementedException();

			//if (data.Equals(null)) throw new Exception("Removing from empty collection");
			//else
			//{
			//	if(data.Remove(item))
			//	{
			//		count--;
			//		return true;
			//	}
			//	else
			//	{
			//		return false;
			//	}
			//}
		}

		public IEnumerator<T> EnumerateAll()
		{
			for (int i = 0; i < count; i++)
			{
				yield return data.ElementAt(i);
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
