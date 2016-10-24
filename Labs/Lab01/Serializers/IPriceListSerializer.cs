namespace Lab01.Serializers
{
    public interface IPriceListSerializer<T>
    {
        void Serialize(PriceList<T> priceList, string path);
        PriceList<T> Deserialize(string path);
    }
}
