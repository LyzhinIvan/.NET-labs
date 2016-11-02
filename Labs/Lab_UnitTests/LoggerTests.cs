using System.IO;
using Lab01;
using NUnit.Framework;

namespace Lab_UnitTests
{
	/// <summary>
	/// Тестирование логгера
	/// </summary>
	[TestFixture]
	class LoggerTests
	{
		private ICarFactory carFactory;

		[SetUp]
		public void SetUp()
		{
			var stream = new StreamWriter("config.txt");
			stream.WriteLine("Kama517 165/70 R15");
			stream.WriteLine("Kama519 175/80 R16");
			stream.Close();
			carFactory = new AutoVaz(new KamaFactory("config.txt"), new AlcastaFactory());
		}

		[Test]
		public void LoggerTest()
		{
			Assert.DoesNotThrow(() =>
			{
				var logger = new CarFactoryLogger(LoggingType.File, "log.txt");
				logger.AddFactory(carFactory);
				carFactory.CreateSedan();
				logger.DeleteFactory(carFactory);
				carFactory.CreateEstate();
				logger.EndLog();
			});
		}
	}
}
