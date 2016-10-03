using System;

namespace Lab01
{
    public abstract class Tire : IComparable
    {
        public string Name { get; }
        public int ProfileWidth { get; }
        public int ProfileHeight { get; }
        public CarcassType Type { get; }
        public int Diameter { get; }

        protected Tire(string name, int profileWidth, int profileHeight, CarcassType type, int diameter)
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
