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

        return Street == other.Street &&
               City == other.City &&
               Country == other.Country &&
               Postcode == other.Postcode;
    }

    public override string ToString()
    {
        return $"Street: {Street}, City: {City}, Country: {Country}, Postcode: {Postcode}";
    }
}