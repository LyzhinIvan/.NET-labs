using System;

namespace Lab01
{
	/// <summary>
	/// Класс Колесо
	/// </summary>
    public class Wheel
    {
		/// <summary> Шина колеса </summary>
        public Tire Tire { get; private set; }
		/// <summary> Диск колеса </summary>
        public Rim Rim { get; private set; }

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="tire">Шина</param>
		/// <param name="rim">Диск</param>
        public Wheel(Tire tire, Rim rim)
        {
            if(tire.Diameter!=rim.Diameter || tire.ProfileWidth!=rim.ProfileWidth)
                throw new Exception("Диаметр и/или ширина профиля диска не соответствуют данной шине");
            Tire = tire;
            Rim = rim;
        }
    }
}
