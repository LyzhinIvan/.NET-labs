using System.IO;
using Lab01;
using NUnit.Framework;

namespace Lab_UnitTests
{
	/// <summary>
	/// Тестирование класса Tire
	/// </summary>
	[TestFixture]
	class TireTests
	{
		/// <summary>
		/// Тестирование создания через конструктор
		/// </summary>
		[Test]
		public void CreationTest()
		{
			var tire = new Tire("Tire1", 165, 70, CarcassType.Diagonal, 15);
			Assert.AreEqual("Tire1", tire.Name);
			Assert.AreEqual(165, tire.ProfileWidth);
			Assert.AreEqual(70, tire.ProfileHeight);
			Assert.AreEqual(CarcassType.Diagonal, tire.Type);
			Assert.AreEqual(15, tire.Diameter);
		}

		/// <summary>
		/// Тестирование создания из строки
		/// </summary>
		[Test]
		public void CreateFromString()
		{
			var tireString = "Tire 165/70 R15";
			var tire = Tire.FromString(tireString);
			Assert.AreEqual("Tire", tire.Name);
			Assert.AreEqual(165, tire.ProfileWidth);
			Assert.AreEqual(70, tire.ProfileHeight);
			Assert.AreEqual(CarcassType.Radial, tire.Type);
			Assert.AreEqual(15, tire.Diameter);
		}

		/// <summary>
		/// Тестирование перевода в строку
		/// </summary>
		[Test]
		public void ToStringTest()
		{
			var tire = new Tire("Tire1", 165, 70, CarcassType.Diagonal, 15);
			Assert.AreEqual("Tire1 165/70 D15", tire.ToString());
		}

		/// <summary>
		/// Тестирование клонирования
		/// </summary>
		[Test]
		public void CloneTest()
		{
			var tire = new Tire("Tire1", 165, 70, CarcassType.Diagonal, 15);
			var newTire = tire.Clone();
			Assert.AreEqual(tire, newTire);
		}

		/// <summary>
		/// Тестирование сравнения
		/// </summary>
		[Test]
		public void CompareToTest()
		{
			var tire1 = new Tire("Tire1", 165, 70, CarcassType.Diagonal, 15);
			var tire2 = new Tire("Tire1", 165, 70, CarcassType.Diagonal, 16);
			Assert.AreEqual(-1, tire1.CompareTo(tire2));
			Assert.AreEqual(0, tire1.CompareTo(tire1));
			Assert.AreEqual(1, tire2.CompareTo(tire1));
		}
	}
}
