public class XmlContent : IContent
{
    public string GetContent()
    {
        return $"Hello {nameof(XmlContent)}";
    }
}