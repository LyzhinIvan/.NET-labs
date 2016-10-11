namespace Lab01
{
    public class CarCreationEventArgs : CarFactoryEventArgs
    {
        public CarType CarType { get; set; }

        public CarCreationEventArgs(EventType eventType, string factoryName, string model, CarType carType) 
            : base(eventType, factoryName, model)
        {
            CarType = carType;
        }
    }
}