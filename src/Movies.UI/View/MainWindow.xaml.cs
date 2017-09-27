using System;
using System.Windows;
using System.Windows.Input;
using Movies.UI;

namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			DataContext = new ViewModel.ApplicationViewModel();
			/*MainListBox.Items.Add(10);
			MainListBox.Items.Add(10);
			MainListBox.Items.Add(10);
			MainListBox.Items.Add(10);
			MainListBox.Items.Add(10);*/
		}

		private void AddFilm_Click(object sender, RoutedEventArgs e)
		{
			AddFilm form1 = new AddFilm();
			form1.Show();
		}
	}
}
