using System.Collections.Generic;

namespace Lab01
{
	/// <summary>
	/// Класс Машина
	/// </summary>
    public class Car
    {
		/// <summary>
		/// Модель машины
		/// </summary>
        public string Model { get; set; }

		/// <summary>
		/// Колеса, установленные на машине
		/// </summary>
        public List<Wheel> Wheels { get; set; }
    }
}
