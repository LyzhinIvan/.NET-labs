using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Lab01.Serializers
{
    public class TirePriceListXmlSerializer : ITirePriceListSerializer
    {
        [Serializable]
        public struct Pair
        {
            public Tire Key { get; set; }
            public double Value { get; set; }
        }

        public void Serialize(PriceList<Tire> priceList, string path)
        {
            var arr = priceList.Select(item => new Pair() {Key = item.Key, Value = item.Value}).ToArray();
            
            using (var stream = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate), Encoding.UTF8))
            {
                new XmlSerializer(arr.GetType()).Serialize(stream, arr);
            }
        }

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