using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab01;

namespace Lab02
{
    class CatalogEnumerator<T> : IEnumerator<T>
    {
        private readonly List<T> elements;
        private int index;

        public CatalogEnumerator(IEnumerable<T> elements)
        {
            this.elements = elements.ToList();
            index = -1;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index + 1 == elements.Count)
                return false;
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public T Current => elements[index];

        object IEnumerator.Current => Current;
    }
}