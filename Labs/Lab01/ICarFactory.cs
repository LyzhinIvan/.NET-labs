using System;
using System.Collections.Generic;

namespace Lab01
{
    public delegate void CarCreationHandler(object sender, string model, CarType carType);

    public delegate void CarRepairHandler(object sender, string model, IEnumerable<string> details);

    public interface ICarFactory
    {
        Car CreateSedan();
        Car CreateHatchback();
        Car CreateEstate();
        
        event CarCreationHandler CarCreated;
        event CarRepairHandler CarRepaired;
    }
}
