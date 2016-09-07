namespace Lab01
{
    public interface ITireFactory
    {
        Tire CreateTire(int profileWidth, int profileHeight, CarcassType type, int diameter);
    }
}
