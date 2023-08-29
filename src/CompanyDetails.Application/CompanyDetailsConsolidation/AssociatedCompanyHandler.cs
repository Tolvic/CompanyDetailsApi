using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.EqualityComparers;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public class AssociatedCompanyHandler : ConsolidationHandler
{
    public override void Handle(CompanyDetailsRequest request, List<CompanyDetailsResponse> responsesToConsolidate,
        CompanyDetailsResponse consolidatedResponse)
    {
        var companyDetailsWithAssociatedCompanies = responsesToConsolidate
            .Where(x => x.AssociatedEntities != null && x.AssociatedEntities.Companies.Any())
            .ToList();

        switch (companyDetailsWithAssociatedCompanies.Count)
        {
            case 0:
                break;
            case 1:
                consolidatedResponse.AssociatedEntities ??= new AssociatedEntities();
                consolidatedResponse.AssociatedEntities.Companies = companyDetailsWithAssociatedCompanies.First().AssociatedEntities!.Companies;
                break;
            default:
                consolidatedResponse.AssociatedEntities ??= new AssociatedEntities();
                consolidatedResponse.AssociatedEntities.Companies = ConsolidateMultiple(companyDetailsWithAssociatedCompanies);
                break;
        }
        
        base.Handle(request, responsesToConsolidate, consolidatedResponse); ;
    }

    private List<Company> ConsolidateMultiple(List<CompanyDetailsResponse> companyDetailsWithAssociatedPersons)
    {
        var result = new List<Company>();
        
        foreach (var response in companyDetailsWithAssociatedPersons)
        {
            foreach (var company in response.AssociatedEntities!.Companies)
            {
                if (!result.Contains(company, new CompanyComparer()))
                {
                    result.Add(company);
                }
            }
        }

        return result;
    }
}