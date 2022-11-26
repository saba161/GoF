using FactoryMethod.Domain;

namespace FactoryMethod.Factories;

public class AppleFactory : ITechnicFactory
{
    public IPhone BuildPhones(string type)
    {
        switch (type)
        {
            case "Iphone":
                return new ApplePhone();
            case "Laptop":
                return new SamsungPhone();
            default: throw new ApplicationException("Error");
        }
    }

    public ILaptop BuildLaptop(string type)
    {
        switch (type)
        {
            case "Samsung":
                return new SamsungLaptop();
            default: throw new ApplicationException("Error");
        }
    }
}