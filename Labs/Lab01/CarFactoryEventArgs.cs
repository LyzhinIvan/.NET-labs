using System;

namespace Lab01
{
    public class CarFactoryEventArgs : EventArgs
    {
        public CarFactoryEventArgs(EventType eventType, string factoryName, string model)
        {
            EventType = eventType;
            FactoryName = factoryName;
            Model = model;
        }

        public EventType EventType { get; }
        public string FactoryName { get; }
        public string Model { get; }
    }
}