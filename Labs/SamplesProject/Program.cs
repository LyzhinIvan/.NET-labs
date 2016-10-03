using System;
using System.Net;
using Lab01;
using Lab02;

namespace SamplesProject
{
    class Program
    {
        delegate int MyDelegate(int a, int b);

        static void Main(string[] args)
        {
            var catalog = new Catalog<Tire>() {new HakkapeliittaTire(), new Kama519Tire(), new Kama521Tire()};
            catalog.PerformAction(PrintTire);
            var diameteres = catalog.SelectField(SelectDiameter);
            catalog.Sort(DiameterComparer);
            catalog.PerformAction(PrintTire);

            MyDelegate del = Sum;
            del += Sub;

            int c = del(3, 2); // c = 1
            Console.WriteLine(c); 

        }

        static int Sum(int a, int b)
        {
            return a + b;
        }

        static int Sub(int a, int b)
        {
            return a - b;
        }

        static void PrintTire(Tire tire)
        {
            Console.WriteLine(tire.ToString());
        }

        static void PrintOnlyName(Tire tire)
        {
            Console.WriteLine(tire.Name);
        }

        static object SelectDiameter(Tire tire)
        {
            return tire.Diameter;
        }

        static bool DiameterComparer(Tire t1, Tire t2)
        {
            return t1.Diameter < t2.Diameter;
        }
        
    }
}
