public class HttpContent : IContent
{
    public string GetContent()
    {
        return $"Hello {nameof(HttpContent)}";
    }
}