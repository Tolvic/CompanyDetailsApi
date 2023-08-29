using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.EqualityComparers;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public class ActivitiesHandler : ConsolidationHandler
{
    public override void Handle(CompanyDetailsRequest request, List<CompanyDetailsResponse> responsesToConsolidate,
        CompanyDetailsResponse consolidatedResponse)
    {
        var companyDetailsWithActivities = responsesToConsolidate
            .Where(x => x.CompanyDetails != null && x.CompanyDetails.Activities.Any())
            .ToList();
        
        
        switch (companyDetailsWithActivities.Count)
        {
            case 0:
                break;
            case 1:
                consolidatedResponse.CompanyDetails ??= new Core.Models.CompanyDetails();
                consolidatedResponse.CompanyDetails.Activities = companyDetailsWithActivities.First().CompanyDetails!.Activities;
                break;
            default:
                consolidatedResponse.CompanyDetails ??= new Core.Models.CompanyDetails();
                consolidatedResponse.CompanyDetails.Activities = ConsolidateMultiple(companyDetailsWithActivities);
                break;
        }

        base.Handle(request, responsesToConsolidate, consolidatedResponse); 
    }
    
    private List<Activity> ConsolidateMultiple(List<CompanyDetailsResponse> responsesToConsolidate)
    {
        var result = new List<Activity>();

        foreach (var response in responsesToConsolidate)
        {
            result = result.Union(response.CompanyDetails!.Activities, new ActivityComparer()).ToList();
        }
        
        return result;
    }
}