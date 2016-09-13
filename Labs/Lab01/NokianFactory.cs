using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01
{
    public class NokianFactory : ITireFactory
    {
        private static readonly List<Tire> ManufacturedTires = new List<Tire>
        {
            new HakkapeliittaTire()
        };

        public Tire CreateTire(int profileWidth, int profileHeight, CarcassType type, int diameter) =>
            (from tire in ManufacturedTires
             where tire.ProfileWidth == profileWidth && tire.ProfileHeight == profileHeight && tire.Type == type && tire.Diameter == diameter
             select (Tire)Activator.CreateInstance(tire.GetType()))
            .FirstOrDefault();  
    }
        
    public class HakkapeliittaTire : Tire
    {
        public HakkapeliittaTire() : base("Hakkapeliitta", 170, 70, CarcassType.Radial, 15)
        {
        }
    }
}