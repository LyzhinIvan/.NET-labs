namespace Lab02
{
    public class PriceListItem<T>
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
