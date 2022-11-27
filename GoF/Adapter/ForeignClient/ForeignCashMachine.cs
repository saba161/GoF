namespace Adapter.ForeignClient;

public class ForeignCashMachine
{
    /// <summary>
    /// Список чеков, хранящихся в кассовом аппарате.
    /// </summary>
    private List<Check> _checks = new List<Check>();

    public string Name { get; private set; }

    /// <summary>
    /// Массив чеков, хранящихся в кассовом аппарате.
    /// </summary>
    public Check[] Checks => _checks.ToArray();

    /// <summary>
    /// Текущий заполняемый чек.
    /// </summary>
    public Check CurrentCheck => _checks.LastOrDefault();

    public ForeignCashMachine()
    {
        var rnd = new Random();
        Name = $"KKA{rnd.Next(10000, 99999)}";
        _checks.Add(new Check());
    }

    /// <summary>
    /// Добавить товар в текущий чек.
    /// </summary>
    /// <param name="name">Наименование товара.</param>
    /// <param name="price">Стоимость товара.</param>
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

    /// <summary>
    /// Сохранить чек.
    /// </summary>
    /// <remarks>
    /// Возвращается копия последнего заполненного кассового чека,
    /// а в кассовом аппарате заводится новый пустой чек.
    /// </remarks>
    /// <returns>Чек.</returns>
    public Check Save()
    {
        var check = (Check)CurrentCheck.Clone();
        _checks.Add(new Check());
        return check;
    }

    /// <summary>
    /// Приведение объекта к строке.
    /// </summary>
    /// <returns>Название кассового аппарата.</returns>
    public override string ToString()
    {
        return Name;
    }
}