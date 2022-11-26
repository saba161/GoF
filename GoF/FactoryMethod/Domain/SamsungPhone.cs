namespace FactoryMethod.Domain;

public class SamsungPhone : IPhone
{
    public string GetPhoneName(string name)
    {
        return "Phone from Samsung company";
    }
}