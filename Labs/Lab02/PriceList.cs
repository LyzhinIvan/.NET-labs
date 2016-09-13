using Lab01;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab02
{
    public interface IPriceList<out T>
    { }

    public class PriceList<T> : ICollection<T>, ICloneable, IPriceList<T> where T:class
    {
        private Dictionary<T, double> priceListItems;

        public PriceList()
        {
            priceListItems = new Dictionary<T, double>();
        }

        public void Add(T item, double price)
        {
            priceListItems.Add(item, price);
        }

        public void Add(T item)
        {
            Add(item, 0);
        }

        public void Clear()
        {
            priceListItems.Clear();
        }

        public bool Contains(T element)
        {
            return priceListItems.ContainsKey(element);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            priceListItems.Keys.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return priceListItems.Remove(item);
        }

        public double GetPrice(T element)
        {
            return priceListItems[element];
        }

        public int Count
        {
            get
            {
                return priceListItems.Count;
            }
        }

        public bool IsReadOnly { get; }

        public object Clone()
        {
            var copy = new PriceList<T>();
            copy.priceListItems = priceListItems;
            return copy;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return priceListItems.Keys.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new PriceListEnumerator<T>(priceListItems);
        }
    }
}
