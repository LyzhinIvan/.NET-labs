namespace Lab02
{
    public class PriceListItem<T> where T : class
    {
        public T Item { get; }
        public double Price { get; }

        public PriceListItem(T item, double price)
        {
            Item = item;
            Price = price;
        }
    }
}
