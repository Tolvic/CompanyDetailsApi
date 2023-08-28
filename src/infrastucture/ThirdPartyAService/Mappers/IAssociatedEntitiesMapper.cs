using CompanyDetails.Core.Models;
using ThirdPartyAService.DTOs;

namespace ThirdPartyAService.Mappers;

public interface IAssociatedEntitiesMapper
{
    AssociatedEntities Map(CompanyInfo companyInfo);
}