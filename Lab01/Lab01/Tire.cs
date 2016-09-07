namespace Lab01
{
    public abstract class Tire
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
    }

    public enum CarcassType
    {
        Diagonal,
        Radial,
        BiasBelt
    }
}
