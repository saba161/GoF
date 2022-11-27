namespace Adapter.ForeignClient;

public class Check : ICloneable
{
    /// <summary>
    /// Список товаров в кассовом чеке.
    /// </summary>
    private List<ForeignProduct> _products;

    public int Number { get; private set; }

    /// <summary>
    /// Date create check
    /// </summary>
    public DateTime DateTime { get; private set; }

    /// <summary>
    /// items in check
    /// </summary>
    public IReadOnlyList<ForeignProduct> Products => _products;

    /// <summary>
    /// Create a check instance.
    /// </summary>
    public Check()
    {
        var rnd = new Random();

        Number = rnd.Next(10000, 99999);
        DateTime = DateTime.Now;
        _products = new List<ForeignProduct>();
    }

    /// <summary>
    /// Add item to check.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="price"></param>
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

    /// <summary>
    /// Create copy check.
    /// </summary>
    /// <returns>Копия чека.</returns>
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