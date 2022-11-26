namespace FactoryMethod.Domain;

public class ApplePhone : IPhone
{
    public string GetPhoneName(string name)
    {
        return "Phone from Apple company";
    }
}