using System.Windows;
using Movies.UI.ViewModel;


namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for FilmNameForm.xaml
	/// </summary>
	public partial class FilmNameForm : Window
    {
        public FilmNameForm(ApplicationViewModel vm)
        {
            InitializeComponent();
			DataContext = vm;
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
