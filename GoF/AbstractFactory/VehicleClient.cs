using AbstractFactory.Domain;
using AbstractFactory.Factories;

namespace AbstractFactory;

public class VehicleClient
{
    private readonly IBike _bike;
    private readonly IScooter _scooter;

    public VehicleClient(IVehicleFactory factory, string type)
    {
        _bike = factory.GetBike(type);
        _scooter = factory.GetScooter(type);
    }

    public string GetBikeName() => _bike.Name();
    public string GetScooterName() => _scooter.Name();
}