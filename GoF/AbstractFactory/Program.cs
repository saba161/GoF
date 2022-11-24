using AbstractFactory;
using AbstractFactory.Factories;

IVehicleFactory honda = new HondaFactory();

VehicleClient vehicleClient = new VehicleClient(honda, "Regular");

Console.WriteLine(vehicleClient.GetBikeName());
Console.WriteLine(vehicleClient.GetScooterName());
