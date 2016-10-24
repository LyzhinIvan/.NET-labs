using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Lab01;
using Lab01.Exceptions;

namespace SamplesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Lab6_Example();
        }

        private static void Lab5_Example()
        {
            try
            {
                var nokianFactory = new NokianFactory("config/nokian.txt");
                Console.WriteLine("Nokian tires:");
                foreach (var tire in nokianFactory.GetAllTires())
                {
                    Console.WriteLine(tire);
                }
            }
            catch (FileFormatException)
            {
                Console.WriteLine("Ошибка в формате файла");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Lab6_Example()
        {
            PriceList<Tire> priceList = new PriceList<Tire>();
            var random = new Random();
            for(int i=0; i<10000; ++i)
                priceList.Add(new Tire("Hakkapelita", 1, 1, CarcassType.Radial, 15), random.Next());
            var progressHolder = new ProgressHolder();
            Thread thread = new Thread(() => priceList.Sort(progressHolder));
            thread.Start();
            Console.WriteLine("Sorting started");
            Console.Write("Progress: 0%");
            while (progressHolder.Progress < 100)
            {
                Console.Write("\rProgress: {0}%", progressHolder.Progress);
                Thread.Sleep(100);
            }
            Console.WriteLine("\rProgress: 100%");
            thread.Join();
            Console.WriteLine("Sorting finished");
            //foreach (KeyValuePair<Tire, double> item in priceList)
            //{
            //    Console.WriteLine("{0} {1}", item.Key, item.Value);
            //}
        }
    }


}
