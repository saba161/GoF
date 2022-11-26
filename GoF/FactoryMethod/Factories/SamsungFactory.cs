using FactoryMethod.Domain;

namespace FactoryMethod.Factories;

public class SamsungFactory : ITechnicFactory
{
    public IPhone BuildPhones(string type)
    {
        throw new NotImplementedException();
    }

    public ILaptop BuildLaptop(string type)
    {
        throw new NotImplementedException();
    }
}