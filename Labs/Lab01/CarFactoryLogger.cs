using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Security.AccessControl;

namespace Lab01
{
    public enum LoggingType
    {
        Console,
        File
    }

    public enum EventType
    {
        CarCreation,
        CarRepair
    }

    public delegate void LogWrite(TextWriter writer, CarFactoryEventArgs args); 

    public class CarFactoryLogger
    {
        private TextWriter writer;

        public event LogWrite Log;

        public CarFactoryLogger(LoggingType loggingType, string filePath = "log.txt")
        {
            writer = loggingType == LoggingType.Console ? System.Console.Out : File.AppendText(filePath);
        }

        public void EndLog()
        {
            writer.Close();
        }

        public void AddFactory(ICarFactory factory)
        {
            factory.CarCreated += OnCarCreated;
            factory.CarRepaired += OnCarRepaired;
        }

        public void DeleteFactory(ICarFactory factory)
        {
            factory.CarCreated -= OnCarCreated;
            factory.CarRepaired -= OnCarRepaired;
        }

        private void OnCarCreated(object sender, string model, CarType carType)
        {
            OnLog(new CarCreationEventArgs(EventType.CarCreation, sender.GetType().Name, model, carType));
        }

        private void OnCarRepaired(object sender, string model, IEnumerable<string> details)
        {
            OnLog(new CarRepairEventArgs(EventType.CarRepair, sender.GetType().Name.ToString(), model, details));
        }

        private void OnLog(CarFactoryEventArgs args)
        {
            Log?.Invoke(writer, args);
        }
    }
}