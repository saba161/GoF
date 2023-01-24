namespace Adapter.MySecondExample;

public class SecondExample
{
}

public interface ITarget
{
    void Request(int x);
}

public class Adapter : ITarget
{
    private readonly IAdaptee _service;

    public Adapter(IAdaptee service)
    {
        _service = service;
    }

    public void Request(int x)
    {
        _service.SpecificRequest("");
    }
}

public interface IAdaptee
{
    void SpecificRequest(string t);
}