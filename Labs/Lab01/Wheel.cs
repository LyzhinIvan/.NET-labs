using System;

namespace Lab01
{
    public class Wheel
    {
        public Tire Tire { get; private set; }
        public Rim Rim { get; private set; }

        public Wheel(Tire tire, Rim rim)
        {
            if(tire.Diameter!=rim.Diameter || tire.ProfileWidth!=rim.ProfileWidth)
                throw new Exception("Диаметр и/или ширина профиля диска не соответствуют данной шине");
            Tire = tire;
            Rim = rim;
        }
    }
}
