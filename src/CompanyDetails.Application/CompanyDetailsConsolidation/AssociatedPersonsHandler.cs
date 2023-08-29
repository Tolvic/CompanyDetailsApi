using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.EqualityComparers;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public class AssociatedPersonsHandler: ConsolidationHandler
{
    public override void Handle(CompanyDetailsRequest request, List<CompanyDetailsResponse> responsesToConsolidate,
        CompanyDetailsResponse consolidatedResponse)
    {
        var companyDetailsWithAssociatedPersons = responsesToConsolidate
            .Where(x => x.AssociatedEntities != null && x.AssociatedEntities.Persons.Any())
            .ToList();

        switch (companyDetailsWithAssociatedPersons.Count)
        {
            case 0:
                break;
            case 1:
                consolidatedResponse.AssociatedEntities ??= new AssociatedEntities();
                consolidatedResponse.AssociatedEntities.Persons = companyDetailsWithAssociatedPersons.First().AssociatedEntities!.Persons;
                break;
            default:
                consolidatedResponse.AssociatedEntities ??= new AssociatedEntities();
                consolidatedResponse.AssociatedEntities.Persons = ConsolidateMultiple(companyDetailsWithAssociatedPersons);
                break;
        }
        
        base.Handle(request, responsesToConsolidate, consolidatedResponse); 
    }

    private List<Person> ConsolidateMultiple(List<CompanyDetailsResponse> companyDetailsWithAssociatedPersons)
    {
        var result = new List<Person>();
        
        foreach (var response in companyDetailsWithAssociatedPersons)
        {
            foreach (var person in response.AssociatedEntities!.Persons)
            {
                if (!result.Contains(person, new PersonComparer()))
                {
                    result.Add(person);
                }
            }
        }

        return result;
    }
}