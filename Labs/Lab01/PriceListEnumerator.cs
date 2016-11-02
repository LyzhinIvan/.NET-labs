using System.Collections.Generic;

namespace Lab01
{
	/// <summary>
	/// Enumerator для прайс-листа
	/// </summary>
    public class PriceListEnumerator<T> : IEnumerator<KeyValuePair<T, double>>
    {
        private List<KeyValuePair<T, double>> items;
        private int index;

        public PriceListEnumerator(List<KeyValuePair<T, double>> items)
        {
            this.items = items;
            this.index = -1;
        }

		/// <summary>
		/// Advances the enumerator to the next element of the collection.
		/// </summary>
		/// <returns>
		/// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
		/// </returns>
		/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
		public bool MoveNext()
        {
            if (index + 1 < items.Count)
            {
                index++;
                return true;
            }
            return false;
        }

		/// <summary>
		/// Sets the enumerator to its initial position, which is before the first element in the collection.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception><filterpriority>2</filterpriority>
		public void Reset()
        {
            index = -1;
        }

		/// <summary>
		/// Gets the element in the collection at the current position of the enumerator.
		/// </summary>
		/// <returns>
		/// The element in the collection at the current position of the enumerator.
		/// </returns>
		KeyValuePair<T, double> IEnumerator<KeyValuePair<T, double>>.Current => items[index];

		/// <summary>
		/// Gets the current element in the collection.
		/// </summary>
		/// <returns>
		/// The current element in the collection.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public object Current => items[index];

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
        {
        }
    }
}