using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab01;

namespace Lab02
{
    class CatalogEnumerator<T> : IEnumerator<T> where T:Tire
    {
        private readonly List<T> tires;
        private int index;

        public CatalogEnumerator(IEnumerable<T> tires)
        {
            this.tires = tires.ToList();
            index = -1;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index + 1 == tires.Count)
                return false;
            index++;
            return true;
        }

        public void Reset()
        {
            index = -1;
        }

        public T Current => tires[index];

        object IEnumerator.Current => Current;
    }
}