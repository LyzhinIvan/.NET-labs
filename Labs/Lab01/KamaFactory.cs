using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01
{
    public class KamaFactory : ITireFactory
    {
        private static readonly List<Tire> ManufacturedTires = new List<Tire>
        {
            new Kama519Tire(),
            new Kama521Tire()
        }; 

        public Tire CreateTire(int profileWidth, int profileHeight, CarcassType type, int diameter) => 
            (from tire in ManufacturedTires
             where tire.ProfileWidth == profileWidth && tire.ProfileHeight == profileHeight && tire.Type == type && tire.Diameter == diameter
             select (Tire) Activator.CreateInstance(tire.GetType()))
            .FirstOrDefault();
    }

    public class Kama519Tire : Tire
    {
        public Kama519Tire() : base("Kama 519", 180, 65, CarcassType.Radial, 14)
        {
        }
    }

    public class Kama521Tire : Tire
    {
        public Kama521Tire() : base("Kama 521", 190, 60, CarcassType.Radial, 15)
        {
        }
    }
}