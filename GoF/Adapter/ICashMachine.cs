namespace Adapter;

public interface ICashMachine
{
    string Number { get; }
    IReadOnlyList<Product> Products { get; }
    string PrintCheck();
    void AddProduct(Product product);
    void Save(string checkText);
}