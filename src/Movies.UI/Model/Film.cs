using System.Runtime.CompilerServices;
using System.ComponentModel;
using System;


namespace FilmLibrary.Model
{
	class Film : INotifyPropertyChanged
	{
		private string title;
		private int age;
		public string Title
		{
			get => title;
			set
			{
				title = value;
				OnPropertyChanged();
			}
		}
		public int Age
		{
			get => age;
			set
			{
				age = value;
				OnPropertyChanged();
			}
		}
		public Film()
		{

		}
		public Film(string Title, int Age)
		{
			this.Title = Title;
			this.Age = Age;
		}
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

	}
}
