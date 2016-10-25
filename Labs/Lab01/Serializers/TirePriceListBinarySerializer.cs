using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Lab01.Serializers
{
    /// <summary>
    /// Бинарный сериализатор для прайс-листа шин
    /// </summary>
    public class TirePriceListBinarySerializer : ITirePriceListSerializer
    {
        [Serializable]
        public struct Pair
        {
            public Tire Key { get; set; }
            public double Value { get; set; }
        }

        /// <summary>
        /// Сериализует прайс-лист шин в бинарный формат и записывает в файл
        /// </summary>
        /// <param name="priceList">Прайс-лист</param>
        /// <param name="path">Путь к файлу</param>
        public void Serialize(PriceList<Tire> priceList, string path)
        {
            var arr = priceList.Select(item => new Pair() { Key = item.Key, Value = item.Value }).ToArray();

            using (var stream = File.Open(path, FileMode.OpenOrCreate))
            {
                new BinaryFormatter().Serialize(stream, arr);
            }
        }


        /// <summary>
        /// Читает из бинарного файла и десериализует в прайс-лист
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Прайс-лист</returns>
        public PriceList<Tire> Deserialize(string path)
        {
            Pair[] arr;
            using (var stream = File.Open(path, FileMode.Open))
            {
                arr = (Pair[])(new BinaryFormatter()).Deserialize(stream);
            }
            var priceList = new PriceList<Tire>();
            foreach (var item in arr)
            {
                priceList.Add(item.Key, item.Value);
            }
            return priceList;
        }
    }
}