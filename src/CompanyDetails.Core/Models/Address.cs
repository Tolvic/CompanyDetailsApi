namespace CompanyDetails.Core.Models;

public class Address : IEquatable<Address>
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? Postcode { get; set; }

    public bool Equals(Address? other)
    {
        if (other == null)
        {
            return false;
        }

        return string.Equals(Street, other.Street, StringComparison.InvariantCultureIgnoreCase) &&
               string.Equals(City, other.City, StringComparison.InvariantCultureIgnoreCase) &&
               string.Equals(Country, other.Country, StringComparison.InvariantCultureIgnoreCase) &&
               string.Equals(Postcode, other.Postcode, StringComparison.InvariantCultureIgnoreCase);
    }

    public override string ToString()
    {
        return $"Street: {Street}, City: {City}, Country: {Country}, Postcode: {Postcode}";
    }
}