using Lab01;
using NUnit.Framework;

namespace Lab_UnitTests
{
	/// <summary>
	/// Тестирование класса Wheel
	/// </summary>
	[TestFixture]
	class WheelTests
	{
		[Test]
		public void WheelTest()
		{
			var wheel = new Wheel(new Tire("Tire", 190, 70, CarcassType.Diagonal, 16), new AlcastaM29Rim());
			Assert.AreEqual(new Tire("Tire", 190, 70, CarcassType.Diagonal, 16), wheel.Tire);
			Assert.AreEqual(new AlcastaM29Rim(), wheel.Rim);
		}
	}
}
