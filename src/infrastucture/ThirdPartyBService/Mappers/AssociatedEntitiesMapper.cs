using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;
using ThirdPartyBService.DTOs;

namespace ThirdPartyBService.Mappers;

public class AssociatedEntitiesMapper : IAssociatedEntitiesMapper
{
    private readonly IDateMapper _dateMapper;
    private readonly ILogger<AssociatedEntitiesMapper> _logger;

    public AssociatedEntitiesMapper(IDateMapper dateMapper, ILogger<AssociatedEntitiesMapper> logger)
    {
        _dateMapper = dateMapper;
        _logger = logger;
    }
    
    public AssociatedEntities Map(CompanyInfo? companyInfo)
    {
        try
        {
            var result = new AssociatedEntities();
            
            if (companyInfo is null) return result;

            MapRelatedPersons(ref result, companyInfo.RelatedPersons);
            MapRelatedCompanies(ref result, companyInfo.RelatedCompanies);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("Error mapping associated entities from ThirdPartyAService: {Exception}", e);
            return new AssociatedEntities();
        }
    }

    private void MapRelatedPersons(ref AssociatedEntities result, List<RelatedPerson>? relatedPersons)
    {
        if (relatedPersons is null) return;
        
        foreach (var relatedPerson in relatedPersons)
        {
            var person = new Person
            {
                FullName = relatedPerson.Name,
                DateFrom = _dateMapper.Map(relatedPerson.DateFrom),
                DateTo = _dateMapper.Map(relatedPerson.DateTo),
                DateOfBirth = _dateMapper.Map(relatedPerson.BirthDate),
                Role = relatedPerson.Type,
                Nationality = relatedPerson.Nationality,

            };

            if (relatedPerson.Ownership is not null)
            {
                var parsed = double.TryParse(relatedPerson.Ownership, System.Globalization.CultureInfo.InvariantCulture, out var ownershipPercentage);
                
                if (parsed)
                {
                    person.OwnershipPercentage = ownershipPercentage;
                }
            }

            result.Persons.Add(person);
        }
    }
    
    private void MapRelatedCompanies(ref AssociatedEntities result, List<RelatedCompany>? relatedCompanies)
    {
        if (relatedCompanies is null) return;
        
        foreach (var relatedCompany in relatedCompanies)
        {
            var company = new Company()
            {
                CompanyName = relatedCompany.Name,
                DateFrom = _dateMapper.Map(relatedCompany.DateFrom),
                DateTo = _dateMapper.Map(relatedCompany.DateTo),
                Role = relatedCompany.Type,
                Country = relatedCompany.Country,
            };
            
            if (relatedCompany.Ownership is not null)
            {
                var parsed = double.TryParse(relatedCompany.Ownership, System.Globalization.CultureInfo.InvariantCulture, out var ownershipPercentage);
                
                if (parsed)
                {
                    company.OwnershipPercentage = ownershipPercentage;
                }
            }
            
            result.Companies.Add(company);
        }
    }
}