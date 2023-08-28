using CompanyDetails.Core.Models;
using ThirdPartyBService.DTOs;

namespace ThirdPartyBService.Mappers;

public interface IAssociatedEntitiesMapper
{
    public AssociatedEntities Map(CompanyInfo? companyInfo);
}