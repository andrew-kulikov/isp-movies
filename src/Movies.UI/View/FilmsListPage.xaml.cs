using Movies.UI.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for FilmsListPage.xaml
	/// </summary>
	public partial class FilmsListPage : Page
	{
		private ApplicationViewModel viewModel;
		public FilmsListPage(ref ApplicationViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
			DataContext = viewModel;
		}

		public void RemoveSelection(object sender, RoutedEventArgs e)
		{
			ActorInfo af = new ActorInfo(viewModel.SelectedFilm.SelectedActor);
			af.ShowDialog();
		}
	}
}
