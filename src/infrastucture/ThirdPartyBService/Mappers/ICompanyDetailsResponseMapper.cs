using CompanyDetails.Core.Models;
using ThirdPartyBService.DTOs;

namespace ThirdPartyBService.Mappers;

public interface ICompanyDetailsResponseMapper
{
    CompanyDetailsResponse Map(CompanyInfo? companyInfo);
}