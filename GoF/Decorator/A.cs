public class A
{
    private readonly IContent _content;

    public A(IContent content)
    {
        _content = content;
    }

    public void Test()
    {
        Console.WriteLine(_content.GetContent());
    }
}