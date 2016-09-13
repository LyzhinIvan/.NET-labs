using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab02
{
    public class PriceList<T> : IEnumerable, ICollection, ICloneable
    {
        private Dictionary<T, double> priceListItems = new Dictionary<T, double>();

        public void Add(T element, double price)
        {
            priceListItems.Add(element, price);
        }

        public bool Contains(T element)
        {
            return priceListItems.ContainsKey(element);
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

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                return null;
            }
        }

        public object Clone()
        {
            var copy = new PriceList<T>();
            copy.priceListItems = priceListItems;
            return copy;
        }

        public void CopyTo(Array array, int index)
        {
            foreach(var item in priceListItems)
            {
                array.SetValue(new PriceListItem<T>(item.Key, item.Value), index++);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new PriceListEnumerator<T>(priceListItems);
        }
    }
}
