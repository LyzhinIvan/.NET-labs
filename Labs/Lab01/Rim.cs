namespace Lab01
{
	/// <summary>
	/// Класс Диск
	/// </summary>
    public abstract class Rim
    {
		/// <summary>
		/// Диаметр диска
		/// </summary>
        public int Diameter { get; }

		/// <summary>
		/// Ширина профиля диска
		/// </summary>
        public int ProfileWidth { get; }

        protected Rim(int diameter, int profileWidth)
        {
            Diameter = diameter;
            ProfileWidth = profileWidth;
        }

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <returns>
		/// true if the specified object  is equal to the current object; otherwise, false.
		/// </returns>
		/// <param name="obj">The object to compare with the current object. </param><filterpriority>2</filterpriority>
		public override bool Equals(object obj)
	    {
		    if (obj == this) return true;
		    if (obj.GetType() != this.GetType()) return false;
			return this.Equals((Rim)obj);
	    }

		/// <summary>
		/// Сравнивает два шины
		/// </summary>
	    protected bool Equals(Rim other)
	    {
		    return Diameter == other.Diameter && ProfileWidth == other.ProfileWidth;
	    }

		/// <summary>
		/// Serves as the default hash function. 
		/// </summary>
		/// <returns>
		/// A hash code for the current object.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
	    {
		    unchecked
		    {
			    return (Diameter*397) ^ ProfileWidth;
		    }
	    }
    }
}