namespace Adapter.ForeignClient;

public class Check : ICloneable
{
    private List<ForeignProduct> _products;

    public int Number { get; private set; }
    
    public DateTime DateTime { get; private set; }

    public IReadOnlyList<ForeignProduct> Products => _products;

    public Check()
    {
        var rnd = new Random();

        Number = rnd.Next(10000, 99999);
        DateTime = DateTime.Now;
        _products = new List<ForeignProduct>();
    }
    
    public void Add(string name, double price)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (price < 0)
        {
            throw new ArgumentException("Цена не может быть меньше нуля.", nameof(price));
        }

        _products.Add(new ForeignProduct(name, price));
    }
    
    public object Clone()
    {
        return new Check()
        {
            _products = _products,
            DateTime = DateTime,
            Number = Number
        };
    }

    public override string ToString()
    {
        var checkText = $"Кассовый чек от {DateTime.ToString("HH:mm dd.MMMM.yyyy")}\r\n";
        checkText += $"Номер чека: {Number}\r\n";
        return checkText;
    }
}