using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace ThirdPartyBService.Mappers;

public class ActivitiesMapper : IActivitiesMapper
{
    private readonly ILogger<ActivitiesMapper> _logger;

    public ActivitiesMapper(ILogger<ActivitiesMapper> logger)
    {
        _logger = logger;
    }
    
    public List<Activity> Map(IEnumerable<DTOs.Activity>? activities)
    {
        try
        {
            var mappedActivities = new List<Activity>();

            if (activities is null)
            {
                return mappedActivities;
            }
            
            foreach (var activity in activities)
            {
                var mappedActivity = new Activity
                {
                    ActivityCode = activity?.ActivityCode.ToString(),
                    ActivityDescription = activity?.ActivityDescription
                };
                
                mappedActivities.Add(mappedActivity);
            }
            
            return mappedActivities;
        }
        catch (Exception e)
        {
            _logger.LogError("Error mapping activities from ThirdPartyBService: {Exception}", e);
            return new List<Activity>();
        }
    }
}