using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab01;

namespace Lab02
{
    public class Catalog<T> : ICollection<T>, ICloneable where T : IComparable
    {
        private readonly List<T> elements = new List<T>();

        
        public IEnumerator<T> GetEnumerator()
        {
            return new CatalogEnumerator<T>(elements);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            elements.Add(item);
        }

        public void Clear()
        {
            elements.Clear();
        }

        public bool Contains(T item)
        {
            return elements.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return elements.Remove(item);
        }

        public int Count => elements.Count;

        public bool IsReadOnly => false;

        public object Clone()
        {
            return new List<T>(elements);
        }

        // Lab3

        public delegate bool Comparer(T a, T b);

        public void PerformAction(Action<T> action)
        {
            foreach (var tire in elements)
            {
                action(tire);
            }
        }

        public List<object> SelectField(Func<T, object> fieldSelector)
        {
            return elements.Select(fieldSelector).ToList();
        }

        public void Sort(Comparer comparer)
        {
            for(int i=0; i<elements.Count; ++i)
                for(int j=i+1; j<elements.Count; ++j)
                    if (!comparer(elements[i], elements[j]))
                    {
                        T temp = elements[i];
                        elements[i] = elements[j];
                        elements[j] = temp;
                    }
        }
    }
}
