using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01
{
    public class AlcastaFactory : IRimFactory
    {
        private static readonly Dictionary<Tuple<int, int>, Type> ManufacturedRims = new Dictionary
            <Tuple<int, int>, Type>()
        {
            {new Tuple<int, int>(16, 190), typeof (AlcastaM29Rim)}
        };

        public Rim CreateRim(int profileWidth, int diameter) => 
            (from manufacturedRim in ManufacturedRims
             where manufacturedRim.Key.Item1 == diameter && manufacturedRim.Key.Item2 == profileWidth
             select (Rim) Activator.CreateInstance(manufacturedRim.Value))
            .FirstOrDefault();
    }

    public class AlcastaM29Rim : Rim
    {
        public AlcastaM29Rim() : base(16, 190)
        {}
    }
}