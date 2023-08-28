using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;
using ThirdPartyAService.DTOs;

namespace ThirdPartyAService.Mappers;

public class AssociatedEntitiesMapper : IAssociatedEntitiesMapper
{
    private readonly IDateMapper _dateMapper;
    private readonly ILogger<AssociatedEntitiesMapper> _logger;
    public const string OwnerRole = "owner";

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

            MapOfficers(ref result, companyInfo.Officers);
            MapOwners(ref result, companyInfo.Owners);

            return result;
        }
        catch (Exception e)
        {
            _logger.LogError("Error mapping associated entities from ThirdPartyAService: {Exception}", e);
            return new AssociatedEntities();
        }
    }

    private void MapOwners(ref AssociatedEntities result, List<Owner>? owners)
    {
        if (owners is null) return;

        foreach (var owner in owners)
        {
            if (IsCompany(owner))
            {
                result.Companies.Add(MapToCompany(owner));
                continue;
            }

            if (IsPerson(owner))
            {
                result.Persons.Add(MapToPerson(owner));
            }
        }
    }
    
    private void MapOfficers(ref AssociatedEntities result, List<Officer>? officers)
    {
        if (officers is null) return;

        foreach (var officer in officers)
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
    }
    
    private Company MapToCompany(Officer officer) => 
        new()
        {
            CompanyName = officer.Name,
            Role = officer.Role,
            DateFrom = _dateMapper.Map(officer.DateFrom),
            DateTo = _dateMapper.Map(officer.DateTo)
        };
    
    private Company MapToCompany(Owner owner) => 
        new()
        {
            CompanyName = owner.Name,
            Role = OwnerRole,
            DateFrom = _dateMapper.Map(owner.DateFrom),
            DateTo = _dateMapper.Map(owner.DateTo),
            OwnershipPercentage = owner.SharesHeld,
            OwnershipType = owner.OwnershipType
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
    
    private Person MapToPerson(Owner owner) => 
        new()
        {
            FirstName = owner.FirstName,
            MiddleNames = owner.MiddleNames,
            LastName = owner.LastName,
            DateOfBirth = _dateMapper.Map(owner.DateOfBirth),
            Role = OwnerRole,
            DateFrom = _dateMapper.Map(owner.DateFrom),
            DateTo = _dateMapper.Map(owner.DateTo),
            OwnershipPercentage = owner.SharesHeld,
            OwnershipType = owner.OwnershipType
        };
    
    private static bool IsCompany(Officer officer) =>
        officer.DateOfBirth is null && officer.FirstName is null && officer.LastName is null;

    private static bool IsPerson(Officer officer) => !IsCompany(officer);
    
    private static bool IsCompany(Owner owner) =>
        owner.DateOfBirth is null && owner.FirstName is null && owner.LastName is null;

    private static bool IsPerson(Owner owner) => !IsCompany(owner);
}