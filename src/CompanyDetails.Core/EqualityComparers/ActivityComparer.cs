using CompanyDetails.Core.Models;

namespace CompanyDetails.Core.EqualityComparers;

public class ActivityComparer : IEqualityComparer<Activity>
{
    public bool Equals(Activity? x, Activity? y)
    {
        if (x == null || y == null)
            return false;

        return x.ActivityCode == y.ActivityCode && x.ActivityDescription == y.ActivityDescription;
    }

    public int GetHashCode(Activity obj)
    {
        return HashCode.Combine(obj.ActivityCode, obj.ActivityDescription);
    }
}