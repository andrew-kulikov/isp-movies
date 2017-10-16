using System;
using System.Windows;
using System.Windows.Input;
using Movies.UI;
using Movies.UI.ViewModel;

namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		ApplicationViewModel viewModel;
		public MainWindow()
		{
			InitializeComponent();
			viewModel = new ApplicationViewModel();
			DataContext = viewModel;
		}
		private void AddFilm_Click(object sender, RoutedEventArgs e)
		{
			
			//viewModel.SelectedAvailableActor = null;
			AddFilm form1 = new AddFilm(viewModel);
			form1.ShowDialog();
		}

		private void RemoveFilm_Click(object sender, RoutedEventArgs e)
		{
			FilmNameForm fn = new FilmNameForm(viewModel);
			fn.ShowDialog();
			viewModel.Remove();
		}

		private void SearchFilm_Click(object sender, RoutedEventArgs e)
		{
			FilmNameForm fn = new FilmNameForm(viewModel);
			fn.ShowDialog();
			viewModel.Find();
		}

		private void ClearSelectedItem(object sender, RoutedEventArgs e)
		{
			ActorViewModel f = new ActorViewModel(viewModel.SelectedFilm.SelectedActor.SourceActor);
			ActorsListBox.UnselectAll();
			viewModel.SelectedFilm.SelectedActor = f;
			ActorInfo af = new ActorInfo(f);
			af.ShowDialog();
		}
	}
}
