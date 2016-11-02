namespace Lab01
{
	/// <summary>
	/// Интерфейс фабрики дисков
	/// </summary>
    public interface IRimFactory
    {
		/// <summary>
		/// Создать диск с заданными параметрами
		/// </summary>
        Rim CreateRim(int profileWidth, int diameter);
    }
}
