﻿using Movies.BusinessLogic.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Specialized;
using System.Windows.Input;
using Movies.UI.Model;

namespace Movies.UI.ViewModel.Collections
{
	public class MyObservableCollection<T> : MyCollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
	{
		private RelayCommand addCommand, removeCommand;
		private T curItem;

		public MyObservableCollection(params T[] items) : base(items)
		{
			CollectionChanged?.Invoke(this,
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
		public T CurItem
		{
			get => curItem;
			set
			{
				curItem = value;
				OnPropertyChanged();
			}
		}

		public void AddObs(T element)
		{
			Add(element);
			CollectionChanged?.Invoke(this,
				new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
		}

		public event NotifyCollectionChangedEventHandler CollectionChanged;
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

		public void OnCollectionChanged(NotifyCollectionChangedEventArgs e) =>
				CollectionChanged?.Invoke(this, e);
	}
}
