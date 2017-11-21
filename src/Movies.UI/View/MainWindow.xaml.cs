using System;
using System.Windows;
using System.Windows.Input;
using Movies.UI;
using Movies.UI.ViewModel;
using System.Windows.Data;
using System.Globalization;

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
			MainFrame.Content = new FilmsListPage(ref viewModel);
		}
		private void AddFilm_Click(object sender, RoutedEventArgs e)
		{
			AddFilm form1 = new AddFilm(viewModel);
			form1.ShowDialog();
		}

		

		private void ClearSelectedItem(object sender, RoutedEventArgs e)
		{
			//ActorsListBox.UnselectAll();
			ActorInfo af = new ActorInfo(viewModel.SelectedFilm.SelectedActor);
			af.ShowDialog();
		}

		private void ListBoxItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			viewModel.Context = Model.Context.Films;
			MainFrame.Content = new FilmsListPage(ref viewModel);
			LinqToFilms.Visibility = Visibility.Visible;
		}
		private void ListBoxItem1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			viewModel.Context = Model.Context.Actors;
			MainFrame.Content = new ActorsListPage(viewModel);
			LinqToFilms.Visibility = Visibility.Collapsed;
		}
		private void ListBoxItem2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			viewModel.Context = Model.Context.Prodecers;
			MainFrame.Content = new ProducersListPage(viewModel);
			LinqToFilms.Visibility = Visibility.Collapsed;
		}
	}
}
