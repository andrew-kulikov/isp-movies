using Movies.UI.ViewModel;
using System.Windows.Controls;

namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for FilmsListPage.xaml
	/// </summary>
	public partial class FilmsListPage : Page
	{
		public FilmsListPage(ApplicationViewModel viewModel)
		{
			InitializeComponent();
			DataContext = viewModel;
		}
	}
}
