using System;
using System.Collections;
using System.Collections.Generic;
using Lab01;

namespace Lab02
{
    //public interface ICatalogOut<out T>
    //{ }

    //public interface ICatalogIn<in T>
    //{ }

    public interface ICatalog<T> : ICollection<T>, ICloneable
    {
    }

    public class Catalog<T> : ICatalog<T> where T : Tire
    {
        private readonly List<T> tires = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return new CatalogEnumerator<T>(tires);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            tires.Add(item);
        }

        public void Clear()
        {
            tires.Clear();
        }

        public bool Contains(T item)
        {
            return tires.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            tires.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return tires.Remove(item);
        }

        public int Count => tires.Count;

        public bool IsReadOnly => false;

        public object Clone()
        {
            return new List<T>(tires);
        }
    }
}
