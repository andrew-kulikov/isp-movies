using System.Windows;
using Movies.UI.ViewModel;


namespace Movies.UI.View
{
	/// <summary>
	/// Interaction logic for ActorInfo.xaml
	/// </summary>
	public partial class ActorInfo : Window
    {
        public ActorInfo(ActorViewModel actorViewModel)
        {
            InitializeComponent();
			DataContext = actorViewModel;
        }
    }
}
