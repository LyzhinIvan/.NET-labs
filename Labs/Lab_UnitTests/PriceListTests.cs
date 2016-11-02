using System.Collections.Generic;
using Lab01;
using NUnit.Framework;

namespace Lab_UnitTests
{
	/// <summary>
	/// Тестирование класса PriceList
	/// </summary>
	[TestFixture]
	class PriceListTests
	{
		private PriceList<Tire> priceList;

		[SetUp]
		public void SetUp()
		{
			priceList = new PriceList<Tire>();
			priceList.Add(new Tire("Tire1", 160, 75, CarcassType.Radial, 15), 2500);
			priceList.Add(new Tire("Tire2", 180, 65, CarcassType.Diagonal, 16), 3000);
			priceList.Add(new Tire("Tire3", 170, 60, CarcassType.BiasBelt, 13), 2700);
		}

		/// <summary>
		/// Тестирование получения и изменения элементов прайс-листа по индексу
		/// </summary>
		[Test]
		public void GetSetTest()
		{
			Assert.AreEqual(new KeyValuePair<Tire, double>(new Tire("Tire2", 180, 65, CarcassType.Diagonal, 16), 3000), priceList[1]);
			priceList[2] = new KeyValuePair<Tire, double>(new Tire("Tire4", 165, 70, CarcassType.BiasBelt, 14), 2900);
			Assert.AreEqual(new Tire("Tire4", 165, 70, CarcassType.BiasBelt, 14), priceList[2].Key);
			Assert.AreEqual(2900, priceList[2].Value);
		}

		/// <summary>
		/// Тестирование сортировки прайс-листа
		/// </summary>
		[Test]
		public void SortTest()
		{
			priceList.Sort();
			Assert.AreEqual(2500, priceList[0].Value);
			Assert.AreEqual(2700, priceList[1].Value);
			Assert.AreEqual(3000, priceList[2].Value);
		}

		/// <summary>
		/// Тестирование очистки прайс-листа
		/// </summary>
		[Test]
		public void ClearTest()
		{
			priceList.Clear();
			Assert.AreEqual(0, priceList.Count);
		}

		/// <summary>
		/// Тестирование копирования прайс-листа
		/// </summary>
		[Test]
		public void CopyToTest()
		{
			var array = new KeyValuePair<Tire, double>[priceList.Count];
			priceList.CopyTo(array, 0);
			CollectionAssert.AreEqual(priceList, array);
		}

		/// <summary>
		/// Тестирование удаления элемента из прайс-листа
		/// </summary>
		[Test]
		public void RemoveTest()
		{
			priceList.Remove(new KeyValuePair<Tire, double>(new Tire("Tire2", 180, 65, CarcassType.Diagonal, 16), 3000));
			Assert.AreEqual(2, priceList.Count);
		}

		/// <summary>
		/// Тестирование поиска элемента в прайс-листе
		/// </summary>
		[Test]
		public void ContainsTest()
		{
			var item = new KeyValuePair<Tire, double>(new Tire("MyTire", 160, 70, CarcassType.Radial, 15), 2600);
			priceList.Add(item);
			Assert.IsTrue(priceList.Contains(item));
		}
	}
}
