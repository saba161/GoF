using AbstractFactory.Domain;

namespace AbstractFactory.Factories;

public interface IVehicleFactory //Main Fabric, which create other fabrics
{
    IBike GetBike(string name);
    IScooter GetScooter(string name);
}