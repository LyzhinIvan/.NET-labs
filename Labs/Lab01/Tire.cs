using System;
using System.Text.RegularExpressions;
using Lab01.Exceptions;

namespace Lab01
{
    [Serializable]
    public class Tire : IComparable, ICloneable
    {
        public string Name { get; set; }
        public int ProfileWidth { get; set; }
        public int ProfileHeight { get; set; }
        public CarcassType Type { get; set; }
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

        public override string ToString()
        {
            return $"{Name} {ProfileWidth}/{ProfileHeight} {Type.ToString()[0]}{Diameter}";
        }

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

        public object Clone()
        {
            return new Tire(Name, ProfileWidth, ProfileHeight, Type, Diameter);
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() != this.GetType()) return -1;
            return this.Diameter.CompareTo(((Tire)obj).Diameter);
        }

	    public override bool Equals(object obj)
	    {
		    if (this == obj) return true;
		    if (obj.GetType() != this.GetType()) return false;
		    return this.Equals((Tire) obj);
	    }

	    private bool Equals(Tire other)
	    {
		    return string.Equals(Name, other.Name) && ProfileWidth == other.ProfileWidth && ProfileHeight == other.ProfileHeight && Type == other.Type && Diameter == other.Diameter;
	    }

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

    public enum CarcassType
    {
        Diagonal,
        Radial,
        BiasBelt
    }
}
