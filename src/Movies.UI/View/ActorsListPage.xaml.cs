using System.Windows.Controls;
using Movies.UI.ViewModel;
using System.Windows;
using System.Windows.Media;

namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for ActorsListPage.xaml
	/// </summary>
	public partial class ActorsListPage : Page
	{
		private ApplicationViewModel viewModel;
		public ActorsListPage(ApplicationViewModel viewModel)
		{
			InitializeComponent();
			this.viewModel = viewModel;
			DataContext = viewModel;
		}
		public void RemoveSelection(object sender, RoutedEventArgs e)
		{
			ActorInfo af = new ActorInfo(viewModel.SelectedActor);
			af.ShowDialog();
		}
	}
}
