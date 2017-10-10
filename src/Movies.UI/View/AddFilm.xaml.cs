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
			DataContext = viewModel.NewFilm;
			for (int i = 1950; i < DateTime.Now.Year + 5; ++i)
			{
				YearBox.Items.Add(i);
			}
			for (int i = 0; i < 22; ++i)
			{
				AgeBox.Items.Add(i);
			}
        }

		public void AddButton_Click(object sender, RoutedEventArgs e)
		{
			if (viewModel.NewFilm.IsReady())
			{
				viewModel.NewFilm.TransformGenres();
				viewModel.Films.AddObs(viewModel.NewFilm);
				viewModel.NewFilm = null;
				Close();
			}
			else
			{
				MessageBox.Show("Incorrect input");
			}
		}
    }
}
