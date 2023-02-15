public class C
{
    private readonly IContent _content;

    public C(IContent content)
    {
        _content = content;
    }
    
    public void Test()
    {
        Console.WriteLine(_content.GetContent());
    }
}