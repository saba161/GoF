namespace FactoryMethod.Domain;

public class SamsungLaptop : ILaptop
{
    public string GetLaptopName(string name)
    {
        return "Laptop from Samsung company";
    }
}