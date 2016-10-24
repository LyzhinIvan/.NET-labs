using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Lab01
{
    public class PriceList<T> : IEnumerable
    {
        private List<KeyValuePair<T, double>>  items = new List<KeyValuePair<T, double>>();

        public void Add(T element, double price)
        {
            items.Add(new KeyValuePair<T, double>(element, price));
        }

        public KeyValuePair<T, double> this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }

        public void Sort(ProgressHolder progressHolder = null)
        {
            for (int i = 0; i < items.Count; ++i)
            {
                for (int j = i + 1; j < items.Count; ++j)
                    if (items[i].Value > items[j].Value)
                    {
                        var temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                if (progressHolder != null)
                    progressHolder.Progress = (int) ((double) (i + 1)*100/items.Count);
            }
        }


        public IEnumerator GetEnumerator()
        {
            return new PriceListEnumerator<T>(items);
        }
    }

    public class PriceListEnumerator<T> : IEnumerator
    {
        private List<KeyValuePair<T, double>> items;
        private int index;

        public PriceListEnumerator(List<KeyValuePair<T, double>> items)
        {
            this.items = items;
            this.index = -1;
        }

        public bool MoveNext()
        {
            if (index + 1 < items.Count)
            {
                index++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current => items[index];
    }
}
