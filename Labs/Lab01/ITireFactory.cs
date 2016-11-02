namespace Lab01
{
	/// <summary>
	/// Интерфейс фабрики шин
	/// </summary>
    public interface ITireFactory
    {
		/// <summary>
		/// Создать шину с заданными параметрами
		/// </summary>
        Tire CreateTire(int profileWidth, int profileHeight, CarcassType type, int diameter);
    }
}
