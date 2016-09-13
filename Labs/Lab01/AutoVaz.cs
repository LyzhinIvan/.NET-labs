using System;
using System.Collections.Generic;

namespace Lab01
{
    class AutoVaz : ICarFactory
    {
        public Car CreateCar(string name, ITireFactory tireFactory, IRimFactory rimFactory)
        {
            if (name == "2101")
            {
                var car = new Car {Wheels = new List<Wheel>()};
                for(int i=0; i<4; ++i)
                    car.Wheels.Add(new Wheel(tireFactory.CreateTire(160, 65, CarcassType.Radial, 13), rimFactory.CreateRim(160, 13)));
                return car;
            }
            if (name == "2106")
            {
                var car = new Car { Wheels = new List<Wheel>() };
                for (int i = 0; i < 4; ++i)
                    car.Wheels.Add(new Wheel(tireFactory.CreateTire(170, 75, CarcassType.Radial, 14), rimFactory.CreateRim(170, 14)));
                return car;
            }
            throw new Exception("AutoVaz не производит автомобиль " + name);
        }
    }
}