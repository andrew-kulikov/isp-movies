using System.Windows.Controls;
using Movies.UI.ViewModel;

namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for ProducersListPage.xaml
	/// </summary>
	public partial class ProducersListPage : Page
	{
		public ProducersListPage(ApplicationViewModel viewModel)
		{
			InitializeComponent();
			DataContext = viewModel;
		}
	}
}
