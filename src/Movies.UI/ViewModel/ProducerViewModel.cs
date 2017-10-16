using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;


namespace Movies.UI.ViewModel
{
    public class ProducerViewModel
    {
		private Producer producer;
		public ProducerViewModel(string name, string surname, DateTime birthDate, MyCollection<Film> films)
		{
			producer = new Producer(name, surname, birthDate, films);
			producer.Films = films;
		}

		public ProducerViewModel()
		{
			producer = new Producer(); 
		}

		public string FullName => producer.Name + " " + producer.Surname;

		public MyCollection<Film> Films
		{
			get => producer.Films;
			set
			{
				producer.Films = value;
				OnPropertyChanged();
			}
		}
		public string Name
		{
			get => producer.Name;
			set
			{
				producer.Name = value;
				OnPropertyChanged();
			}
		}

		public string Surname
		{
			get => producer.Surname;
			set
			{
				producer.Surname = value;
				OnPropertyChanged();
			}
		}

		public DateTime BirthDate
		{
			get => producer.BirthDate;
			set
			{
				producer.BirthDate = value;
				OnPropertyChanged();
			}
		}

		public int BirthDay
		{
			get => producer.BirthDate.Day;
			set => producer.BirthDate = 
				new DateTime(producer.BirthDate.Year, producer.BirthDate.Month, value);
		}

		public int BirthMonth
		{
			get => producer.BirthDate.Month;
			set => producer.BirthDate =
				new DateTime(producer.BirthDate.Year, value, producer.BirthDate.Day);
		}

		public int BirthYear
		{
			get => producer.BirthDate.Year;
			set => producer.BirthDate = 
				new DateTime(value, producer.BirthDate.Month, producer.BirthDate.Day);
		}

		public Producer Source => producer;

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
