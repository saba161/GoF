namespace AbstractFactory.Domain;

public class RegularBike : IBike
{
    public string Name()
    {
        return "Regular Bike";
    }
}