namespace Adapter.ForeignClient;

public class ForeignCashMachine
{
    private List<Check> _checks = new List<Check>();
    public string Name { get; private set; }
    public Check[] Checks => _checks.ToArray();
    public Check CurrentCheck => _checks.LastOrDefault();

    public ForeignCashMachine()
    {
        var rnd = new Random();
        Name = $"KKA{rnd.Next(10000, 99999)}";
        _checks.Add(new Check());
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

        CurrentCheck.Add(name, price);
    }
    
    public Check Save()
    {
        var check = (Check)CurrentCheck.Clone();
        _checks.Add(new Check());
        return check;
    }
    
    public override string ToString()
    {
        return Name;
    }
}