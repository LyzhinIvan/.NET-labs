using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab01.Serializers
{
    /// <summary>
    /// Сериализатор XML для прайс-листа шин
    /// </summary>
    public class TirePriceListXmlSerializer : ITirePriceListSerializer
    {
        /// <summary>
        /// Вспомогательная структура для сериализации/десериализации KeyValeuPair
        /// </summary>
        [Serializable]
        public struct Pair
        {
            public Tire Key { get; set; }
            public double Value { get; set; }
        }

        /// <summary>
        /// Сериализует прайс-лист шин в формат XML и записывает в файл
        /// </summary>
        /// <param name="priceList">Прайс-лист</param>
        /// <param name="path">Путь к файлу</param>
        public void Serialize(PriceList<Tire> priceList, string path)
        {
            var arr = priceList.Select(item => new Pair() {Key = item.Key, Value = item.Value}).ToArray();
            
            using (var stream = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate), Encoding.UTF8))
            {
                new XmlSerializer(arr.GetType()).Serialize(stream, arr);
            }
        }

        /// <summary>
        /// Читает из файла XML и десериализует в прайс-лист
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Прайс-лист</returns>
        public PriceList<Tire> Deserialize(string path)
        {
            Pair[] arr;
            using (var stream = new StreamReader(path, Encoding.UTF8))
            {
                arr = (Pair[]) (new XmlSerializer(typeof(Pair[]))).Deserialize(stream);
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