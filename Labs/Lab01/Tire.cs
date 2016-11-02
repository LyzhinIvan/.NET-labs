using System;
using System.Text.RegularExpressions;
using Lab01.Exceptions;

namespace Lab01
{
	/// <summary>
	/// Класс Шина
	/// </summary>
    [Serializable]
    public class Tire : IComparable, ICloneable
    {
		/// <summary> Название шины </summary>
        public string Name { get; set; }
		/// <summary> Ширина профиля </summary>
        public int ProfileWidth { get; set; }
		/// <summary> Высота профиля </summary>
        public int ProfileHeight { get; set; }
		/// <summary> Тип каркаса шины </summary>
        public CarcassType Type { get; set; }
		/// <summary> Диаметр шины </summary>
        public int Diameter { get; set; }

        public Tire()
        {
        }

        public Tire(string name, int profileWidth, int profileHeight, CarcassType type, int diameter)
        {
            Name = name;
            ProfileWidth = profileWidth;
            ProfileHeight = profileHeight;
            Type = type;
            Diameter = diameter;
        }

		/// <summary>
		/// Преобразование в строку
		/// </summary>
        public override string ToString()
        {
            return $"{Name} {ProfileWidth}/{ProfileHeight} {Type.ToString()[0]}{Diameter}";
        }

		/// <summary>
		/// Создание шины из строкового представления
		/// </summary>
		/// <param name="str">Строковое представление (пример: "Hakkapelita 175/60 R15")</param>
        public static Tire FromString(string str)
        {
            Regex regex = new Regex("^(\\w+) (\\d+)/(\\d+) (D|R|B)(\\d+)$");
            if (!regex.IsMatch(str))
                throw new FileFormatException();
            var match = regex.Match(str);
            CarcassType carcassType = match.Groups[4].Value == "D"
                ? CarcassType.Diagonal
                : (match.Groups[4].Value == "R" ? CarcassType.Radial : CarcassType.BiasBelt);
            return new Tire(match.Groups[1].Value, int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value), carcassType, int.Parse(match.Groups[5].Value));
        }

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>
		/// A new object that is a copy of this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public object Clone()
        {
            return new Tire(Name, ProfileWidth, ProfileHeight, Type, Diameter);
        }

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj"/> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj"/>. Greater than zero This instance follows <paramref name="obj"/> in the sort order. 
		/// </returns>
		/// <param name="obj">An object to compare with this instance. </param><exception cref="T:System.ArgumentException"><paramref name="obj"/> is not the same type as this instance. </exception><filterpriority>2</filterpriority>
		public int CompareTo(object obj)
        {
            if (obj.GetType() != this.GetType()) return -1;
            return this.Diameter.CompareTo(((Tire)obj).Diameter);
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
		    if (this == obj) return true;
		    if (obj.GetType() != this.GetType()) return false;
		    return this.Equals((Tire) obj);
	    }

		/// <summary>
		/// Сравнение с другой шиной
		/// </summary>
	    private bool Equals(Tire other)
	    {
		    return string.Equals(Name, other.Name) && ProfileWidth == other.ProfileWidth && ProfileHeight == other.ProfileHeight && Type == other.Type && Diameter == other.Diameter;
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
			    var hashCode = Name?.GetHashCode() ?? 0;
			    hashCode = (hashCode*397) ^ ProfileWidth;
			    hashCode = (hashCode*397) ^ ProfileHeight;
			    hashCode = (hashCode*397) ^ (int) Type;
			    hashCode = (hashCode*397) ^ Diameter;
			    return hashCode;
		    }
	    }
    }
}
