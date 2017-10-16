using Movies.BusinessLogic.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Movies.UI.ViewModel.Collections
{
	public class MyObservableCollection<T> : MyCollection<T>, INotifyCollectionChanged
	{
		public MyObservableCollection(params T[] items) : base(items)
		{
			CollectionChanged?.Invoke(this,
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public MyObservableCollection(MyObservableCollection<T> items) : base(items.data)
		{
			CollectionChanged?.Invoke(this,
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}

		public void AddObs(T element)
		{
			Add(element);
			CollectionChanged?.Invoke(this,
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
		

		public bool RemoveObs(string name)
		{
			foreach(T element in data)
			{
				if (element is FilmViewModel)
				{
					if ((element as FilmViewModel).Name == name)
					{
						bool res = Remove(element);
						CollectionChanged?.Invoke(this,
							new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
						return res;
					}
				}
				if (element is ActorViewModel)
				{
					if ((element as ActorViewModel).FullName == name)
					{
						bool res = Remove(element);
						CollectionChanged?.Invoke(this,
							new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
						return res;
					}
				}
			}
			
			return false;
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public void OnCollectionChanged(NotifyCollectionChangedEventArgs e) =>
				CollectionChanged?.Invoke(this, e);
	}
}
