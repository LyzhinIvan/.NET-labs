using System;
using System.IO;
using Lab01;
using NUnit.Framework;

namespace Lab_UnitTests
{
	/// <summary>
	/// Тестирование класса Autovaz
	/// </summary>
	[TestFixture]
	class AutovazTests
	{
		[SetUp]
		public void SetUp()
		{
			var stream = new StreamWriter("config.txt");
			stream.WriteLine("Hakkapellita 165/70 R15");
			stream.WriteLine("Hakkapellita8 175/80 R16");
			stream.Close();
		}

		/// <summary>
		/// Тестирование создания машины
		/// </summary>
		[Test]
		public void CarCreationTests()
		{
			var autovaz = new AutoVaz(new NokianFactory("config.txt"), new AlcastaFactory());
			var sedan = autovaz.CreateSedan();
			Assert.AreEqual("Ваз 2110", sedan.Model);
			var hatchback = autovaz.CreateHatchback();
			Assert.AreEqual("Ваз 2112", hatchback.Model);
			var estate = autovaz.CreateEstate();
			Assert.AreEqual("Ваз 2111", estate.Model);
		}

		/// <summary>
		/// Тестирование ремонта машины
		/// </summary>
		[Test]
		public void CarRepairTest()
		{
			var autovaz = new AutoVaz(new NokianFactory("config.txt"), new AlcastaFactory());
			var car = autovaz.CreateSedan();
			Assert.DoesNotThrow(() => autovaz.RepairCar(car));
		}

	}
}
