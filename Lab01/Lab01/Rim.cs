namespace Lab01
{
    public abstract class Rim
    {
        public int Diameter { get; }

        public int ProfileWidth { get; }

        protected Rim(int diameter, int profileWidth)
        {
            Diameter = diameter;
            ProfileWidth = profileWidth;
        }
    }
}