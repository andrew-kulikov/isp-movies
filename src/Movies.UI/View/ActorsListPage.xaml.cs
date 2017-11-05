﻿using System.Windows.Controls;
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
		public ActorsListPage(ApplicationViewModel viewModel)
		{
			InitializeComponent();
			DataContext = viewModel;
		}
	}
}
