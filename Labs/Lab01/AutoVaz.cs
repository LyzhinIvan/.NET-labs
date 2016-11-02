using System.Collections.Generic;

namespace Lab01
{
	/// <summary>
	/// Класс - фабрика Автоваз
	/// </summary>
    public class AutoVaz : ICarFactory
    {
        private ITireFactory tireFactory;
        private IRimFactory rimFactory;

	    /// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="tireFactory">Шинная фабрика</param>
		/// <param name="rimFactory">Фабрика дисков</param>
        public AutoVaz(ITireFactory tireFactory, IRimFactory rimFactory)
        {
            this.tireFactory = tireFactory;
            this.rimFactory = rimFactory;
        }


		/// <summary>
		/// Создать седан
		/// </summary>
		/// <returns>Машина - седан</returns>
		public Car CreateSedan()
        {
            var sedan = new Car() {Model = "Ваз 2110"};
            OnCarCreated("Ваз 2110", CarType.Sedan);
            return sedan;
        }

		/// <summary>
		/// Создать хетчбек
		/// </summary>
		/// <returns>Машина - хетчбек</returns>
		public Car CreateHatchback()
        {
            var hatchback = new Car() { Model = "Ваз 2112"};
            OnCarCreated("Ваз 2112", CarType.Hatchback);
            return hatchback;
        }

		/// <summary>
		/// Создать универсал
		/// </summary>
		/// <returns>Машина - универсал</returns>
		public Car CreateEstate()
        {
            var estate = new Car() { Model = "Ваз 2111"};
            OnCarCreated("Ваз 2111", CarType.Estate);
            return estate;
        }

		/// <summary>
		/// Отремонтировать машину
		/// </summary>
		/// <param name="car">Машина</param>
		public void RepairCar(Car car)
        {
            OnCarRepaired(car.Model, new List<string>() {"двигатель", "коробка передач"});
        }

        public event CarCreationHandler CarCreated;
        public event CarRepairHandler CarRepaired;

        protected virtual void OnCarCreated(string model, CarType carType)
        {
            CarCreated?.Invoke(this, model, carType);
        }

        protected virtual void OnCarRepaired(string model, IEnumerable<string> details )
        {
            CarRepaired?.Invoke(this, model, details);
        }
    }

    
}