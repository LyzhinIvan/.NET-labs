using System;
using System.Collections.Generic;

namespace Lab01
{
    public delegate void CarCreationHandler(object sender, string model, CarType carType);

    public delegate void CarRepairHandler(object sender, string model, IEnumerable<string> details);

    public interface ICarFactory
    {
		/// <summary>
		/// Создать седан
		/// </summary>
		/// <returns>Машина - седан</returns>
        Car CreateSedan();
		
		/// <summary>
		/// Создать хетчбек
		/// </summary>
		/// <returns>Машина - хетчбек</returns>
        Car CreateHatchback();

		/// <summary>
		/// Создать универсал
		/// </summary>
		/// <returns>Машина - универсал</returns>
        Car CreateEstate();

		/// <summary>
		/// Отремонтировать машину
		/// </summary>
		/// <param name="car">Машина</param>
	    void RepairCar(Car car);
        
        event CarCreationHandler CarCreated;
        event CarRepairHandler CarRepaired;
    }
}
