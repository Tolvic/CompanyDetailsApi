using CompanyDetails.Core.Models;

namespace ThirdPartyBService.Mappers;

public interface IActivitiesMapper
{
    public List<Activity> Map(IEnumerable<DTOs.Activity>? activities);
}