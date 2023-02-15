public class B
{
    private readonly IContent _content;

    public B(IContent content)
    {
        _content = content;
    }
    
    public void Test()
    {
        Console.WriteLine(_content.GetContent());
    }
}