namespace Adapter;

public class Product
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public Product(string name, decimal price)
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