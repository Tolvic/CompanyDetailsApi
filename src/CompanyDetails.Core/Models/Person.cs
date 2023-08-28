namespace CompanyDetails.Core.Models;

public class Person : Entity
{
    public string? FullName { get; set; }
    public string? FirstName { get; set; }
    public string? MiddleNames { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Nationality { get; set; }
    public double? OwnershipPercentage { get; set; }
}