public class D
{
    private readonly IContent _content;

    public D(IContent content)
    {
        _content = content;
    }

    public void Test()
    {
        Console.WriteLine(_content.GetContent());
    }
}