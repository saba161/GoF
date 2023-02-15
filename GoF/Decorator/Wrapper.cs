public class Wrapper : IContent
{
    private readonly IContent _content;

    public Wrapper(IContent content)
    {
        _content = content;
    }
    public string GetContent()
    {
        Console.WriteLine("Start");
        var result = this._content.GetContent();
        Console.WriteLine("End");
        return result;
    }
}