using Movies.BusinessLogic;
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
			bool res = true;
			if (typeof(T) == typeof(FilmViewModel)) {
				foreach (var film in data)
				{
					if ((film as FilmViewModel)?.Name == (element as FilmViewModel)?.Name)
					{
						res = false;
					}
				}
			}
			else if (typeof(T) == typeof(ActorViewModel))
			{
				foreach (var actor in data)
				{
					if ((actor as ActorViewModel)?.Name == (element as ActorViewModel)?.Name)
					{
						res = false;
					}
				}
			}
			else if (typeof(T) == typeof(ProducerViewModel))
			{
				foreach (var prod in data)
				{
					if ((prod as ProducerViewModel)?.Name == (element as ProducerViewModel)?.Name)
					{
						res = false;
					}
				}
			}
			if (res)
			{
				Add(element);
			}
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
				if (element is ProducerViewModel)
				{
					if ((element as ProducerViewModel).FullName == name)
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
		public void Refresh()
		{
			CollectionChanged?.Invoke(this,
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}


		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public void OnCollectionChanged(NotifyCollectionChangedEventArgs e) =>
				CollectionChanged?.Invoke(this, e);
	}
}
