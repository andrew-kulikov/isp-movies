using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.UI.ViewModel;

namespace Movies.UI.Tests.Collections
{
	[TestClass]
	public class MyObservableCollectionTests
	{
		[TestMethod]
		public void ObservableCollection_Init_OK()
		{
			ApplicationViewModel vm = new ApplicationViewModel();
			Assert.AreEqual(vm.Films.Count, 4);
		}
	}
}
