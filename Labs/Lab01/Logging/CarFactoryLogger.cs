using System.Collections.Generic;
using System.IO;

namespace Lab01
{
	/// <summary>
	/// Тип логирования
	/// </summary>
    public enum LoggingType
    {
        Console,
        File
    }

	/// <summary>
	/// Тип события
	/// </summary>
    public enum EventType
    {
        CarCreation,
        CarRepair
    }

    public delegate void LogWrite(TextWriter writer, CarFactoryEventArgs args); 

	/// <summary>
	/// Класс, логирующий действия, происходящие на фабриках, которые ему указали
	/// </summary>
    public class CarFactoryLogger
    {
        private TextWriter writer;

        public event LogWrite Log;

		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="loggingType">Тип логирования</param>
		/// <param name="filePath" optinal="true" default="log.txt">Файл для записи лога</param>
        public CarFactoryLogger(LoggingType loggingType, string filePath = "log.txt")
        {
            writer = loggingType == LoggingType.Console ? System.Console.Out : File.AppendText(filePath);
        }

		/// <summary>
		/// Завершить логирование и записать все в файл
		/// </summary>
        public void EndLog()
        {
            writer.Close();
        }

		/// <summary>
		/// Добавить фабрику, действия которой логгер должен отслеживать
		/// </summary>
		/// <param name="factory">Фабрика для добавления</param>
        public void AddFactory(ICarFactory factory)
        {
            factory.CarCreated += OnCarCreated;
            factory.CarRepaired += OnCarRepaired;
        }

		/// <summary>
		/// Удалить фабрику, которую больше не нужно отслеживать
		/// </summary>
		/// <param name="factory">Фабрика для удаления</param>
        public void DeleteFactory(ICarFactory factory)
        {
            factory.CarCreated -= OnCarCreated;
            factory.CarRepaired -= OnCarRepaired;
        }

		/// <summary>
		/// Обработчк события создания машины
		/// </summary>
        private void OnCarCreated(object sender, string model, CarType carType)
        {
            OnLog(new CarCreationEventArgs(EventType.CarCreation, sender.GetType().Name, model, carType));
        }

		/// <summary>
		/// Обработчик события ремонта машины
		/// </summary>
        private void OnCarRepaired(object sender, string model, IEnumerable<string> details)
        {
            OnLog(new CarRepairEventArgs(EventType.CarRepair, sender.GetType().Name.ToString(), model, details));
        }

		/// <summary>
		/// Фукнция логирования
		/// </summary>
        private void OnLog(CarFactoryEventArgs args)
        {
            Log?.Invoke(writer, args);
        }
    }
}