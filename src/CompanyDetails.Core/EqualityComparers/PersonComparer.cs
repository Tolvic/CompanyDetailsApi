using CompanyDetails.Core.Models;

namespace CompanyDetails.Core.EqualityComparers;

public class PersonComparer : IEqualityComparer<Person>
{
    public bool Equals(Person? x, Person? y)
    {
        if (x == null || y == null)
            return false;

        return x.FirstName == y.FirstName &&
               x.MiddleNames == y.MiddleNames &&
               x.LastName == y.LastName &&
               x.DateOfBirth == y.DateOfBirth;
    }

    public int GetHashCode(Person obj)
    {
        return HashCode.Combine(obj.FirstName, obj.MiddleNames, obj.LastName, obj.DateOfBirth);
    }
}