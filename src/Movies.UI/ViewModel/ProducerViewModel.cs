using Movies.BusinessLogic;
using Movies.BusinessLogic.Collections;
using System;


namespace Movies.UI.ViewModel
{
    public class ProducerViewModel : PersonViewModel
    {
		private Producer producer;
		public ProducerViewModel(string name, string surname, DateTime birthDate, MyCollection<Film> films)
			: base(name, surname, birthDate)
		{
			producer = person as Producer;
			producer.Films = films;
		}
		public MyCollection<Film> Films
		{
			get => producer.Films;
			set
			{
				producer.Films = value;
				OnPropertyChanged();
			}
		}
	}
}
