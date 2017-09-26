using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Movies.BusinessLogic;

namespace Movies.UI.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
		protected Person person;
		public PersonViewModel(string name, string surname, DateTime birthDate)
		{
			person = new Person(name, surname, birthDate);
		}

		public string Name
		{
			get => person.Name;
			set
			{
				person.Name = value;
				OnPropertyChanged();
			}
		}

		public string Surname
		{
			get => person.Surname;
			set
			{
				person.Surname = value;
				OnPropertyChanged();
			}
		}

		public DateTime BirthDate
		{
			get => person.BirthDate;
			set
			{
				person.BirthDate = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "") =>
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}
