using System;
using System.Text.RegularExpressions;
using Lab01.Exceptions;

namespace Lab01
{
    public class Tire : IComparable, ICloneable
    {
        public string Name { get; }
        public int ProfileWidth { get; }
        public int ProfileHeight { get; }
        public CarcassType Type { get; }
        public int Diameter { get; }

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
            Regex regex = new Regex("$(\\w+) ([0-9]+)/([0-9]+) (D|R|B)([0-9]+)^");
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
    }

    public enum CarcassType
    {
        Diagonal,
        Radial,
        BiasBelt
    }
}
