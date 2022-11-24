using AbstractFactory.Domain;

namespace AbstractFactory.Factories;

public class HondaFactory : IVehicleFactory
{
    public IBike GetBike(string name)
    {
        switch (name)
        {
            case "Regular":
                return new RegularBike();
            case "Sport":
                return new SportBike();
            default: throw new ApplicationException("Exception");
        }
    }

    public IScooter GetScooter(string name)
    {
        switch (name)
        {
            case "Regular":
                return new RegularScooter();
            case "Sport":
                return new SportScooter();
            default: throw new ApplicationException("Exception");
        }
    }
}