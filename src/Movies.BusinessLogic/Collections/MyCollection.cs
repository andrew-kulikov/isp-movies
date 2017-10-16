using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Movies.BusinessLogic.Collections
{
	public class MyCollection<T> : ICollection<T>
	{
		protected T[] data;
		protected int cursor;

		public MyCollection()
		{
			cursor = 0;
			data = new T[0];
		}

		public MyCollection(params T[] items)
			:this()
		{
			Add(items);
		}

		public int Count => cursor;

		public T this[int i] {
			get {
				if (i > cursor)
				{
					throw new IndexOutOfRangeException("Index is out of range");
				}
				return data[i];
			}
		}

		public bool IsReadOnly => false;

		public void Add(T item)
		{
			if (item != null)
			{
				if (cursor + 1 >= data.Length)
				{
					Array.Resize(ref data, (cursor + 1) * 2);
				}
				data[cursor++] = item;
			}
		}

		public void Add(params T[] items)
		{
			for (int i = 0; i < items?.Length; i++)
			{
				Add(items[i]);
			}
		}

		public void Add(MyCollection<T> coll)
		{
			if (coll.Equals(null))
			{
				throw new ArgumentNullException("Argument is null");
			}
			Add(coll.data);
		}

		public void Clear()
		{
			for (int i = 0; i  < cursor; i++)
			{
				data[i] = default(T);
			}
			Array.Resize(ref data, 1);
			cursor = 0;
		}

		public T[] ToArray() => data;

		public bool Contains(T item) => data.Contains(item);

		public void CopyTo(T[] array, int arrayIndex = 0)
		{
			if (arrayIndex + cursor > array.Length)
			{
				throw new OverflowException("Array overflow");
			}
			else
			{
				var items = data.ToArray();
				for (int i = arrayIndex; i < arrayIndex + cursor; i++)
				{
					array[i] = items[i - arrayIndex];
				}
			}
			
		}

		public T ElementAt(int pos)
		{
			return data[pos];
		}

		public IEnumerator<T> GetEnumerator() => new MyEnumerator<T>(this);

		public bool Remove(T item)
		{
			bool res = false;
			for (int i = 0; i < Count; i++)
			{
				if (item.Equals(data[i]))
				{
					for (int j = i; j < Count - 1; j++)
					{
						data[j] = data[j + 1];
					}
					if (i == Count - 1)
					{
						data[i] = default(T);
					}
					res = true;
					break;
				}
			}
			if (res)
			{
				cursor--;
				if (data.Length / 4 >= cursor)
				{
					Array.Resize(ref data, cursor);
				}
			}
			return res;
		}

		public IEnumerator<T> EnumerateAll()
		{
			for (int i = 0; i < cursor; i++)
			{
				yield return data[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}
