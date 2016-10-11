using System.Collections.Generic;

namespace Lab01
{
    public class Car
    {
        public string Model { get; set; }
        public List<Wheel> Wheels { get; set; }
    }

    public enum CarType
    {
        Sedan,
        Hatchback,
        Estate
    }
}
