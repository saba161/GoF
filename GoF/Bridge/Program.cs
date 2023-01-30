using Bridge;

DateTime now = DateTime.Now;

var license1 = new TwoDaysLicense("Secret Life of Pets", now);
var license2 = new LifeLongLicense("Matrix", now);

PrintLicenseDetails(license1);
PrintLicenseDetails(license2);

void PrintLicenseDetails(MovieLicense license)
{
    Console.WriteLine($"Movie: {license.Movie}");
    Console.WriteLine($"Price: {GetPrice(license)}");
    Console.WriteLine($"Valid for: {GetValidFor(license)}");

    Console.WriteLine();
}

string GetPrice(MovieLicense movieLicense)
{
    return $"${movieLicense.GetPrice():0.00}";
}

string GetValidFor(MovieLicense license)
{
    DateTime? experationDate = license.GetExpirationDate();

    if (experationDate == null)
        return "Forever";

    TimeSpan timeSpan = experationDate.Value - DateTime.Now;

    return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}";
}