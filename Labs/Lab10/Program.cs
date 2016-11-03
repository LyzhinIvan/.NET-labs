using System;
using Lab01;

namespace Lab10
{
	class Program
	{
		static void Main(string[] args)
		{
			var priceList=  new PriceList<Tire>();
			priceList.Add(new Tire("Kama1", 160, 70, CarcassType.Radial, 15), 2000);
			priceList.Add(new Tire("Kama2", 170, 80, CarcassType.Radial, 16), 3000);
			priceList.Add(new Tire("Kama3", 175, 75, CarcassType.Radial, 15), 2500);
			priceList.Add(new Tire("Kama4", 165, 65, CarcassType.Radial, 14), 2800);
			priceList.Add(new Tire("Kama5", 160, 70, CarcassType.Radial, 13), 3500);
			Console.WriteLine("Diameter = 15");
			foreach (var tire in priceList.WithDiameterEqual(15))
			{
				Console.WriteLine(tire);
			}
			Console.WriteLine("Price > 2500");
			foreach (var tire in priceList.WithPriceGreaterThan(2500))
			{
				Console.WriteLine(tire);
			}
		}
	}
}
