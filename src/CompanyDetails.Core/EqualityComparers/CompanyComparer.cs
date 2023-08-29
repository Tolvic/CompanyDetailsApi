using CompanyDetails.Core.Models;

namespace CompanyDetails.Core.EqualityComparers;

public class CompanyComparer : IEqualityComparer<Company>
{
    public bool Equals(Company? x, Company? y)
    {
        if (x == null || y == null)
            return false;

        return x.CompanyName == y.CompanyName;
    }

    public int GetHashCode(Company obj)
    {
        return HashCode.Combine(obj.CompanyName);
    }
}