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
        public AddFilm(ApplicationViewModel vm)
        {
            InitializeComponent();
			DataContext = vm;
			for (int i = 1950; i < DateTime.Now.Year + 5; ++i)
			{
				YearBox.Items.Add(i);
			}
			for (int i = 0; i < 22; ++i)
			{
				AgeBox.Items.Add(i);
			}
        }
    }
}
