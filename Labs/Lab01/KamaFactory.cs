using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab01
{
    public class KamaFactory : ITireFactory
    {
        private static readonly List<Tire> ManufacturedTires = new List<Tire>();

        public KamaFactory(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException();
            foreach (var line in File.ReadLines(filePath).Where(line => !string.IsNullOrEmpty(line.Trim())))
            {
                ManufacturedTires.Add(Tire.FromString(line));
            }
        }

        public Tire CreateTire(int profileWidth, int profileHeight, CarcassType type, int diameter) => 
            (from tire in ManufacturedTires
             where tire.ProfileWidth == profileWidth && tire.ProfileHeight == profileHeight && tire.Type == type && tire.Diameter == diameter
             select (Tire)tire.Clone())
            .FirstOrDefault();

        public IEnumerable<Tire> GetAllTires()
        {
            return ManufacturedTires.Select(t => (Tire)t.Clone());
        }
        
    }
}