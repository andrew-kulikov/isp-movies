using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Movies.BusinessLogic.Collections;

namespace Movies.BusinessLogic.Tests.Collections
{
	[TestClass]
	public class MyCollectionTests
	{
		[TestMethod]
		public void Add_OneItemToEmpty_OK()
		{
			MyCollection<int> collection = new MyCollection<int>();

			collection.Add(10);

			Assert.AreEqual(1, collection.Count);
			Assert.AreEqual(10, collection[0]);
		}

		[TestMethod]
		public void Add_OneItemToNotEmpty_OK()
		{
		}
	}
}
