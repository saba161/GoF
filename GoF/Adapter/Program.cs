using Adapter;
using Adapter.Adapter;
using Adapter.ForeignClient;

class Program
{
    static void Main(string[] args)
    {
        CashMachine myCashMachine = new();
        ForeignCashMachine foreignCashMachine = new();

        var products = new List<Product>
        {
            new Product("Samsung SSD 256Gb", 9600),
            new Product("Crucial RAM DDR3 4Gb", 2500),
            new Product("Intel CPU Core-i7 6400", 8000)
        };

        products.ForEach(p => myCashMachine.AddProduct(p));
        var check = myCashMachine.PrintCheck();
        Console.WriteLine(check);

        List<(string, double)> productsForForeighnCash = new List<(string, double)>
        {
            ("Samsung SSD 256Gb", 9600),
            ("Crucial RAM DDR3 4Gb", 2500),
            ("Intel CPU Core-i7 6400", 8000)
        };

        productsForForeighnCash.ForEach(p => foreignCashMachine.Add(p.Item1, p.Item2));
        Console.WriteLine(foreignCashMachine.Save());

        ForeignCashMachineAdapter adapter = new(foreignCashMachine);
        products.ForEach(p => adapter.AddProduct(p));
        var newCheck = myCashMachine.PrintCheck();
        Console.WriteLine(check);
    }

    private static void TestCashMachine(ICashMachine cashMachine, List<Product> products)
    {
        products.ForEach(p => cashMachine.AddProduct(p));

        var check = cashMachine.PrintCheck();

        Console.WriteLine(check);
        Console.ReadLine();
    }
}