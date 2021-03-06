﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;

namespace Lab01
{
    /// <summary>
    /// Коллекция для хранения объектов и их цен
    /// </summary>
    /// <typeparam name="T">Тип хранимых объектов</typeparam>
    [Serializable]
    public class PriceList<T> : ICollection<KeyValuePair<T, double>>
    {
        private List<KeyValuePair<T, double>>  items = new List<KeyValuePair<T, double>>();

        /// <summary>
        /// Добавление элемента в прайс-лист
        /// </summary>
        /// <param name="element">Элемент</param>
        /// <param name="price">Цена</param>
        public void Add(T element, double price)
        {
            items.Add(new KeyValuePair<T, double>(element, price));
        }

        /// <summary>
        /// Обращение к элементу прайс-листа по индексу
        /// </summary>
        /// <param name="i">Индекс</param>
        /// <returns>Элемент прайс-листа</returns>
        public KeyValuePair<T, double> this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }

        /// <summary>
        /// Сортирует элементы по цене
        /// </summary>
        /// <param name="progressHolder">Объект, позволяющий следить за прогрессом сортировки</param>
        public void Sort(ProgressHolder progressHolder = null)
        {
            Console.WriteLine("{0} Sorting started", Thread.CurrentThread.ManagedThreadId);

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

            Console.WriteLine("{0} Sorting finished", Thread.CurrentThread.ManagedThreadId);

        }

        // Имплементация интерфейса ICollection

        IEnumerator<KeyValuePair<T, double>> IEnumerable<KeyValuePair<T, double>>.GetEnumerator()
        {
            return new PriceListEnumerator<T>(items);
        }

        public IEnumerator GetEnumerator()
        {
            return new PriceListEnumerator<T>(items);
        }

        public void Add(KeyValuePair<T, double> item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(KeyValuePair<T, double> item)
        {
            return items.Contains(item);
        }

        public void CopyTo(KeyValuePair<T, double>[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<T, double> item)
        {
            return items.Remove(item);
        }

        public int Count => items.Count;
        public bool IsReadOnly => false;
    }
}
