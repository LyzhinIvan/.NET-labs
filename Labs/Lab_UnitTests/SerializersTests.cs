using Lab01;
using Lab01.Serializers;
using NUnit.Framework;

namespace Lab_UnitTests
{
	/// <summary>
	/// Тестирование сериализаторов
	/// </summary>
	[TestFixture]
    public class SerializersTests
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
		/// Тестирование сериализации/десериализации в JSON
		/// </summary>
		[Test]
		public void JsonSerializerTest()
		{
			var serializer = new TirePriceListJsonSerializer();
			serializer.Serialize(priceList, "serialize.json");
			var newPriceList = serializer.Deserialize("serialize.json");
			CollectionAssert.AreEqual(priceList, newPriceList);
		}

		/// <summary>
		/// Тестирование сериализации/десериализации в XML
		/// </summary>
		[Test]
		public void XmlSerializerTest()
		{
			var serializer = new TirePriceListXmlSerializer();
			serializer.Serialize(priceList, "serialize.xml");
			var newPriceList = serializer.Deserialize("serialize.xml");
			CollectionAssert.AreEqual(priceList, newPriceList);
		}

		/// <summary>
		/// Тестирование сериализации/десериализации в бинарный формат
		/// </summary>
		[Test]
		public void BinSerializerTest()
		{
			var serializer = new TirePriceListBinarySerializer();
			serializer.Serialize(priceList, "serialize.bin");
			var newPriceList = serializer.Deserialize("serialize.bin");
			CollectionAssert.AreEqual(priceList, newPriceList);
		}
	}
}
