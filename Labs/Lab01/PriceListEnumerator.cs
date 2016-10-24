using System.Collections.Generic;

namespace Lab01
{
    public class PriceListEnumerator<T> : IEnumerator<KeyValuePair<T, double>>
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

        KeyValuePair<T, double> IEnumerator<KeyValuePair<T, double>>.Current => items[index];

        public object Current => items[index];

        public void Dispose()
        {
        }
    }
}