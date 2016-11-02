using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Lab01.Serializers
{
    /// <summary>
    /// Сериализатор JSON для прайс-листа шин
    /// </summary>
    public class TirePriceListJsonSerializer : ITirePriceListSerializer
    {
        /// <summary>
        /// Сериализует прайс-лист шин в формат JSON и записывает в файл
        /// </summary>
        /// <param name="priceList">Прайс-лист</param>
        /// <param name="path">Путь к файлу</param>
        public void Serialize(PriceList<Tire> priceList, string path)
        {
	        var str = JsonConvert.SerializeObject(priceList, Formatting.Indented);
	        File.WriteAllText(path, str, Encoding.UTF8);
        }

	    /// <summary>
        /// Читает из файла JSON и десериализует в прайс-лист
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Прайс-лист</returns>
        public PriceList<Tire> Deserialize(string path)
        {
            return JsonConvert.DeserializeObject<PriceList<Tire>>(File.ReadAllText(path, Encoding.UTF8));
        }
    }
}