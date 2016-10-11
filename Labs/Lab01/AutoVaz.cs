using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Lab01
{
    public class AutoVaz : ICarFactory
    {
        private ITireFactory tireFactory;
        private IRimFactory rimFactory;

        public AutoVaz(ITireFactory tireFactory, IRimFactory rimFactory)
        {
            this.tireFactory = tireFactory;
            this.rimFactory = rimFactory;
        }
        
        public Car CreateSedan()
        {
            var sedan = new Car() {Model = "Ваз 2110"};
            OnCarCreated("Ваз 2110", CarType.Sedan);
            return sedan;
        }

        public Car CreateHatchback()
        {
            var hatchback = new Car() { Model = "Ваз 2112"};
            OnCarCreated("Ваз 2112", CarType.Hatchback);
            return hatchback;
        }

        public Car CreateEstate()
        {
            var estate = new Car() { Model = "Ваз 2111"};
            OnCarCreated("Ваз 2111", CarType.Estate);
            return estate;
        }

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