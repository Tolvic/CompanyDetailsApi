using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.EqualityComparers;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public class CompanyDetailsHandler : ConsolidationHandler
{
    public override void Handle(CompanyDetailsRequest request,
        List<CompanyDetailsResponse> responsesToConsolidate,
        CompanyDetailsResponse consolidatedResponse)
    {
        var nonNullCompanyDetails = responsesToConsolidate
            .Where(x => x.CompanyDetails != null)
            .Select(x => x.CompanyDetails)
            .ToList();

        switch (nonNullCompanyDetails.Count)
        {
            case 0:
                break;
            case 1:
                consolidatedResponse.CompanyDetails = nonNullCompanyDetails.First();
                break;
            default:
                consolidatedResponse.CompanyDetails = ConsolidateMultiple(nonNullCompanyDetails!);
                break;
        }

        base.Handle(request, responsesToConsolidate, consolidatedResponse); 
    }

    private Core.Models.CompanyDetails ConsolidateMultiple(List<Core.Models.CompanyDetails> detailsToConsolidate)
    {
        var result = new Core.Models.CompanyDetails();

        foreach (var currentDetails in detailsToConsolidate)
        {
            foreach (var field in SingleValueFieldsToConsolidate)
            {
                var property = typeof(Core.Models.CompanyDetails).GetProperty(field);
                var currentValue = property?.GetValue(currentDetails);
                var existingValue = property?.GetValue(result);
            
                ConsolidateField(result, field, () => existingValue, value => property?.SetValue(result, value), currentValue);
            }
            
            ConsolidateField(result, currentDetails.Activities);
        }
        
        return result;
    }
    
    private static readonly List<string> SingleValueFieldsToConsolidate = new()
    {
        nameof(Core.Models.CompanyDetails.CompanyNumber),
        nameof(Core.Models.CompanyDetails.CompanyName),
        nameof(Core.Models.CompanyDetails.CountryCode),
        nameof(Core.Models.CompanyDetails.CompanyType),
        nameof(Core.Models.CompanyDetails.Status),
        nameof(Core.Models.CompanyDetails.DateEstablished),
        nameof(Core.Models.CompanyDetails.DateDissolved),
        nameof(Core.Models.CompanyDetails.Address),
    };

    private static void ConsolidateField(Core.Models.CompanyDetails consolidateResult,
        List<Activity> activitiesToConsider)
    {
        if (activitiesToConsider.Any())
        {
            var combinedList = consolidateResult.Activities.Union(activitiesToConsider, new ActivityComparer()).ToList();
            consolidateResult.Activities = combinedList;
        }
    }
    
    private static void ConsolidateField<T>(
        Core.Models.CompanyDetails consolidateResult,
        string fieldName,
        Func<T?> getCurrentValue,
        Action<T?> setValue,
        T? valueToConsider)
    {
        var currentValue = getCurrentValue();
    
        if (currentValue == null)
        {
            setValue(valueToConsider);
            return;
        }
    
        if (valueToConsider != null && !valueToConsider.Equals(currentValue))
        {
            AddWarning(consolidateResult, fieldName, $"Alternative value found: {valueToConsider}");
        }
    }
    

    private static void AddWarning(Core.Models.CompanyDetails result, string field, string warning)
    {
        if (result.Warnings.TryGetValue(field, out var existingList))
        {
            existingList.Add(warning);
        }
        else
        {
            var newList = new List<string> { warning };
            result.Warnings.Add(field, newList);
        }
    }
}

