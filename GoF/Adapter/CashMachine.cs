using System.Text;

namespace Adapter;

public class CashMachine : ICashMachine
{
    private List<Product> _products;

    private Guid _number;

    public IReadOnlyList<Product> Products => _products;

    public string Number => _number.ToString();

    public CashMachine()
    {
        _number = Guid.NewGuid();
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        _products.Add(product);
    }

    public string PrintCheck()
    {
        var checkText = GetCheckText();
        Save(checkText);
        return checkText;
    }
    
    public void Save(string checkText)
    {
        if (string.IsNullOrEmpty(checkText))
        {
            throw new ArgumentNullException(nameof(checkText));
        }

        using (var sr = new StreamWriter("checks.txt", true, Encoding.Default))
        {
            sr.WriteLine(checkText);
        }
        _products.Clear();
    }

    public override string ToString()
    {
        return $"Касса №{Number}";
    }

    private string GetCheckText()
    {
        var date = DateTime.Now.ToString("dd MMMM yyyy HH:mm");
        var checkText = $"Cashier's check from {date}\r\n";
        checkText += $"Receipt ID: {Guid.NewGuid()}\r\n";
        checkText += "Product List:\r\n";
        foreach (var product in _products)
        {
            checkText += $"{product.Name}\t\t\t{product.Price}\r\n";
        }
        var sum = _products.Sum(p => p.Price);
        checkText += $"TOTAL\t\t\t{sum}\r\n";
        return checkText;
    }
}