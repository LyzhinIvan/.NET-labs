using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Lab01.Serializers
{
    public class TirePriceListJsonSerializer : ITirePriceListSerializer
    {
        public void Serialize(PriceList<Tire> priceList, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(priceList, Formatting.Indented), Encoding.UTF8);
        }

        public PriceList<Tire> Deserialize(string path)
        {
            return JsonConvert.DeserializeObject<PriceList<Tire>>(File.ReadAllText(path, Encoding.UTF8));
        }
    }
}