using System.Collections.Generic;
using Lab01;

namespace Lab10
{
	static class PriceListExtensions
	{
		/// <summary>
		/// Возвращает шины с ценой больше заданной
		/// </summary>
		/// <param name="priceList">Прайс-лист</param>
		/// <param name="price">Цена</param>
		/// <returns></returns>
		public static IEnumerable<Tire> WithPriceGreaterThan(this PriceList<Tire> priceList, double price)
		{
			foreach (KeyValuePair<Tire, double> item in priceList)
			{
				if (item.Value > price)
					yield return item.Key;
			}
		}

		/// <summary>
		/// Возвращает шины с диаметром равным заданному
		/// </summary>
		/// <param name="priceList">Прайс-лист</param>
		/// <param name="diameter">Диаметр</param>
		/// <returns></returns>
		public static IEnumerable<Tire> WithDiameterEqual(this PriceList<Tire> priceList, int diameter)
		{
			foreach (KeyValuePair<Tire, double> item in priceList)
			{
				if(item.Key.Diameter==diameter)
					yield return item.Key;
			}
		}
	}
}
