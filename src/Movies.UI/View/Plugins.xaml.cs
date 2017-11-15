using System.Windows;
using Movies.UI.ViewModel;

namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for Plugins.xaml
	/// </summary>
	public partial class Plugins : Window
	{
		public Plugins(ApplicationViewModel viewModel)
		{
			InitializeComponent();
			DataContext = viewModel;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Plugs.UnselectAll();
		}
	}
}
