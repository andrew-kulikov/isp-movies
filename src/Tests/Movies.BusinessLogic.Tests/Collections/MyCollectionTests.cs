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
			MyCollection<int> collection = new MyCollection<int>(1, 2, 3);

			collection.Add(10);

			Assert.AreEqual(4, collection.Count);
			Assert.AreEqual(10, collection[3]);
		}

		[TestMethod]
		public void Iterate_Collection_OK()
		{
			MyCollection<int> collection = new MyCollection<int>(1, 2, 3);
			int i = 0;
			foreach (var element in collection)
			{
				Assert.AreEqual(element, collection[i]);
				i++;
			}
		}

		[TestMethod]
		public void	Remove_ExistingElement_OK()
		{
			MyCollection<int> collection = new MyCollection<int>(1, 2, 3);
			Assert.AreEqual(true, collection.Remove(2));
		}
	}
}
