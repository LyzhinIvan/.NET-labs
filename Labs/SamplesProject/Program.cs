using System;
using System.IO;
using System.Linq;
using Lab01;
using Lab02;

namespace SamplesProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleLogger = new CarFactoryLogger(LoggingType.Console);
            var fileLogger = new CarFactoryLogger(LoggingType.File, "mylog.txt");
            consoleLogger.Log += LogWrite;
            fileLogger.Log += LogWrite;

            var factory = new AutoVaz(new NokianFactory(), new AlcastaFactory());
            var car = factory.CreateSedan();
            consoleLogger.AddFactory(factory);
            fileLogger.AddFactory(factory);
            car = factory.CreateEstate();
            factory.RepairCar(car);


            consoleLogger.EndLog();
            fileLogger.EndLog();
        }

        static void LogWrite(TextWriter writer, CarFactoryEventArgs args)
        {
            if (args.EventType == EventType.CarCreation)
                writer.WriteLine("{0} created car {1} ({2})", args.FactoryName, args.Model, ((CarCreationEventArgs)args).CarType);
            else if (args.EventType == EventType.CarRepair)
                writer.WriteLine("{0} repaired car {1}. Repaired details: {2}", args.FactoryName, args.Model, 
                    string.Join(", ", ((CarRepairEventArgs)args).Details));
        }



    }
}
