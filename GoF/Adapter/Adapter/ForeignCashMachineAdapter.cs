﻿using Adapter.ForeignClient;
using System.Text;

namespace Adapter.Adapter;

public class ForeignCashMachineAdapter : ICashMachine
{
    private ForeignCashMachine _foreignCashMachine;

    public string Number => _foreignCashMachine.Name;

    public IReadOnlyList<Product> Products
    {
        get
        {
            var productsTuple = _foreignCashMachine.CurrentCheck.Products;
            var products = productsTuple.Select(s => new Product(s.Name, Convert.ToDecimal(s.Price)));
            return (IReadOnlyList<Product>)products;
        }
    }

    public ForeignCashMachineAdapter(ForeignCashMachine foreignCashMachine)
    {
        _foreignCashMachine = foreignCashMachine
            ?? throw new ArgumentNullException(nameof(foreignCashMachine));
    }

    public void AddProduct(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        _foreignCashMachine.Add(product.Name, Convert.ToDouble(product.Price));
    }

    public string PrintCheck()
    {
        var check = _foreignCashMachine.Save();
        var checkText = GetCheckText(check);
        Save(checkText);
        return checkText;
    }

    public void Save(string checkText)
    {
        if (string.IsNullOrEmpty(checkText))
        {
            throw new ArgumentNullException(nameof(checkText));
        }

        using (var sr = new StreamWriter("checks2.txt", true, Encoding.Default))
        {
            sr.WriteLine(checkText);
        }
    }

    private string GetCheckText(Check check)
    {
        var date = check.DateTime.ToString("dd MMMM yyyy HH:mm");
        var checkText = $"Кассовый чек от {date}\r\n";
        checkText += $"Идентификатор чека: {check.Number}\r\n";
        checkText += "Список товаров:\r\n";
        foreach (var product in check.Products)
        {
            checkText += $"{product.Name}\t\t\t{product.Price}\r\n";
        }
        var sum = check.Products.Sum(p => p.Price);
        checkText += $"ИТОГО\t\t\t{sum}\r\n";
        return checkText;
    }
}