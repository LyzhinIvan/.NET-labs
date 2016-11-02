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

	    public override bool Equals(object obj)
	    {
		    if (obj == this) return true;
		    if (obj.GetType() != this.GetType()) return false;
			return this.Equals((Rim)obj);
	    }

	    protected bool Equals(Rim other)
	    {
		    return Diameter == other.Diameter && ProfileWidth == other.ProfileWidth;
	    }

	    public override int GetHashCode()
	    {
		    unchecked
		    {
			    return (Diameter*397) ^ ProfileWidth;
		    }
	    }
    }
}