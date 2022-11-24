namespace AbstractFactory.Domain;

public class RegularScooter : IScooter
{
    public string Name()
    {
        return "Regular Scooter";
    }
}