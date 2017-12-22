using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Movies.UI.ViewModel;
using Movies.UI.Tools;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Movies.UI.View
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
		private ApplicationViewModel viewModel;
        public About(ApplicationViewModel viewModel)
        {
            InitializeComponent();
			/*int i = 0;
			foreach (var t in MyCollectionsConverter.GetRatings(viewModel.Films))
			{
				p.Points.Add(new Point(++i * 20, t * 15));
			}*/
			
        }
	}
}
