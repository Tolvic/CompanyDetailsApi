namespace CompanyDetails.Core.Models;

public class AssociatedEntities
{
    public List<Person> Persons { get; set; } = new List<Person>();
    public List<Company> Companies { get; set; } = new List<Company>();
}