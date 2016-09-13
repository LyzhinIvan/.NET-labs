namespace Lab01
{
    interface ICarFactory
    {
        Car CreateCar(string name, ITireFactory tireFactory, IRimFactory rimFactory);
    }
}
