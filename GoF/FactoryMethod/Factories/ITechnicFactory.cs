using FactoryMethod.Domain;

namespace FactoryMethod.Factories;

/// <summary>
/// Main Factory, which create technic
/// </summary>
public interface ITechnicFactory
{
    IPhone BuildPhones(string type);
    ILaptop BuildLaptop(string type);
}