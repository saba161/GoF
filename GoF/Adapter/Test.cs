namespace Adapter;

public interface ITest
{

}
public class Test : ITest
{

}

public interface ITest2
{

}

public class Test2 : ITest2
{

}

public class TestAdapter : ITest
{
    private readonly Test2 _test2;

    public TestAdapter(Test2 test2)
    {
        _test2 = test2;
    }
}