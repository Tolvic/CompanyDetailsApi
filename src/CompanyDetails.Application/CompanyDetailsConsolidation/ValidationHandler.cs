using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public class ValidationHandler : ConsolidationHandler
{
    public override void Handle(CompanyDetailsRequest request,
        List<CompanyDetailsResponse> responsesToConsolidate,
        CompanyDetailsResponse consolidatedResponse)
    {

        responsesToConsolidate.RemoveAll(response =>
            response.CompanyDetails?.CompanyNumber != request.CompanyNumber ||
            response.CompanyDetails?.CountryCode != request.JurisdictionCode);

        if (responsesToConsolidate.Count == 0)
        {
            return;
        }
        
        base.Handle(request, responsesToConsolidate, consolidatedResponse); 
              
    }
}