namespace Lab01.Serializers
{
    /// <summary>
    /// Сериализатор для прайс-листа
    /// </summary>
    /// <typeparam name="T">Тип элементов, хранимых в прайс-листе</typeparam>
    public interface IPriceListSerializer<T>
    {
        /// <summary>
        /// Сериализует прайс-лист и записывает в файл
        /// </summary>
        /// <param name="priceList">Прайс-лист</param>
        /// <param name="path">Путь к файлу</param>
        void Serialize(PriceList<T> priceList, string path);

        /// <summary>
        /// Читает из файла и десериализует в прайс-лист
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Прайс-лист</returns>
        PriceList<T> Deserialize(string path);
    }
}
