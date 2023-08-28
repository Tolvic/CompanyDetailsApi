using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;
using ThirdPartyAService.DTOs;

namespace ThirdPartyAService.Mappers;

public class AssociatedEntitiesMapper : IAssociatedEntitiesMapper
{
    private readonly IDateMapper _dateMapper;
    private readonly ILogger<AssociatedEntitiesMapper> _logger;

    public AssociatedEntitiesMapper(IDateMapper dateMapper, ILogger<AssociatedEntitiesMapper> logger)
    {
        _dateMapper = dateMapper;
        _logger = logger;
    }
    
    public AssociatedEntities Map(CompanyInfo companyInfo)
    {
        try
        {
            var result = new AssociatedEntities();

            if (companyInfo.Officers is null) return result;

            foreach (var officer in companyInfo.Officers)
            {
                if (IsCompany(officer))
                {
                    result.Companies.Add(MapToCompany(officer));
                    continue;
                }

                if (IsPerson(officer))
                {
                    result.Persons.Add(MapToPerson(officer));
                }
            }

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("Error mapping associated entities from ThirdPartyAService: {Exception}", e);
            return new AssociatedEntities();
        }
    }
    
    private Company MapToCompany(Officer officer) => 
        new()
        {
            CompanyName = officer.Name,
            Role = officer.Role,
            DateFrom = _dateMapper.Map(officer.DateFrom),
            DateTo = _dateMapper.Map(officer.DateTo)
        };

    private Person MapToPerson(Officer officer) => 
        new()
        {
            FirstName = officer.FirstName,
            MiddleNames = officer.MiddleNames,
            LastName = officer.LastName,
            DateOfBirth = _dateMapper.Map(officer.DateOfBirth),
            Role = officer.Role,
            DateFrom = _dateMapper.Map(officer.DateFrom),
            DateTo = _dateMapper.Map(officer.DateTo)
        };
    
    private static bool IsCompany(Officer officer) =>
        officer.DateOfBirth is null && officer.FirstName is null && officer.LastName is null;

    private static bool IsPerson(Officer officer) => !IsCompany(officer);
}