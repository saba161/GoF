namespace Bridge;

public abstract class MovieLicenseTwo
{
    private readonly Discount _discount;
    public string Movie { get; }
    public DateTime PurchaseTime { get; }

    protected MovieLicenseTwo(string movie, DateTime purchaseTime, Discount discount)
    {
        _discount = discount;
        Movie = movie;
        PurchaseTime = purchaseTime;
    }

    public decimal GetPrice()
    {
        int discount = _discount.GetDiscount();
        decimal multiplier = 1 - discount / 100m;
        return GetPriceCore() * multiplier;
    }

    public abstract decimal GetPriceCore();
    public abstract DateTime? GetExpirationDate();
}

public abstract class Discount
{
    public abstract int GetDiscount();
}

public class NoDiscount : Discount
{
    public override int GetDiscount() => 0;
}

public class MilitaryDiscount : Discount
{
    public override int GetDiscount() => 10;
}

public class SeniorDiscount : Discount
{
    public override int GetDiscount() => 20;
}