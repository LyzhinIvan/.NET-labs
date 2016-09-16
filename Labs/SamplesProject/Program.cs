using System;
using Lab01;
using Lab02;

namespace SamplesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ICatalog<Tire> catalog = new Catalog<Tire>() {new HakkapeliittaTire()};
            Print(catalog);
        }

        static void Print(ICatalog<Tire> tires)
        {
            foreach (var tire in tires)
            {
                Console.WriteLine(tire.ToString());
            }
        }
    }
}
