using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab02
{
    public class PriceListEnumerator<T> : IEnumerator<PriceListItem<T>> where T : class
    {
        private List<PriceListItem<T>> items = new List<PriceListItem<T>>();
        int position = -1;

        public PriceListEnumerator(Dictionary<T, double> priceListItems)
        {
            foreach (var item in priceListItems)
                items.Add(new PriceListItem<T>(item.Key, item.Value));
        }

        public PriceListItem<T> Current
        {
            get
            {
                try
                {
                    return items[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            position++;
            return position < items.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
