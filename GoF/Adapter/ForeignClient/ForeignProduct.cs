namespace Adapter.ForeignClient;

public class ForeignProduct
{
    public string Name { get; set; }

    public double Price { get; set; }

    public ForeignProduct(string name, double price)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (price < 0)
        {
            throw new ArgumentException("Цена не может быть меньше нуля.", nameof(price));
        }

        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return Name;
    }
}