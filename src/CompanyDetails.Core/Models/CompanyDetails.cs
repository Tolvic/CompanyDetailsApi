namespace CompanyDetails.Core.Models;

public class CompanyDetails
{
    public string? CompanyNumber { get; set; }
    public string? CompanyName { get; set; }
    public string? CountryCode { get; set; }
    public string? CompanyType { get; set; }
    public string? Status { get; set; }
    public DateOnly? DateEstablished { get; set; }
    public DateOnly? DateDissolved { get; set; }
    public Address? Address { get; set; }
    public List<Activity> Activities { get; set; } = new List<Activity>();
}