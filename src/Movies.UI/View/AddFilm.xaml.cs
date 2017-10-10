using System;
using System.Windows;
using Movies.UI.ViewModel;

namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for AddFilm.xaml
	/// </summary>
	public partial class AddFilm : Window
    {
		private ApplicationViewModel viewModel;
        public AddFilm(ApplicationViewModel applicationViewModel)
        {
            InitializeComponent();
			viewModel = applicationViewModel;
			DataContext = viewModel;
			for (int i = 1950; i < DateTime.Now.Year + 5; ++i)
			{
				YearBox.Items.Add(i);
			}
			for (int i = 0; i < 22; ++i)
			{
				AgeBox.Items.Add(i);
			}
			for (int i = 1930; i <= DateTime.Now.Year - 10; ++i)
			{
				ActorBirthYearBox.Items.Add(i);
			}
			for (int i = 1; i <= 12; ++i)
			{
				ActorBirthMonthBox.Items.Add(i);
			}
			for (int i = 1; i <= 31; ++i)
			{
				ActorBirthDayBox.Items.Add(i);
			}
		}

		public void AddButton_Click(object sender, RoutedEventArgs e)
		{
			if (viewModel.NewFilm.IsReady())
			{
				viewModel.NewFilm.TransformGenres();
				viewModel.Films.AddObs(viewModel.NewFilm);
				viewModel.NewFilm = new FilmViewModel();
				Close();
			}
			else
			{
				MessageBox.Show("Incorrect input");
			}
		}

		private void AddActorToFilm_Click(object sender, RoutedEventArgs e)
		{
			viewModel.NewActor.Films.Add(viewModel.NewFilm.Source);
			viewModel.NewFilm.Actors.Add(viewModel.NewActor);
			viewModel.Actors.Add(viewModel.NewActor);
			viewModel.NewActor = new ActorViewModel();
		}
	}
}
