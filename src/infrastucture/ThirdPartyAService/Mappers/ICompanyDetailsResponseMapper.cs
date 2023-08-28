using CompanyDetails.Core.Models;
using ThirdPartyAService.DTOs;

namespace ThirdPartyAService.Mappers;

public interface ICompanyDetailsResponseMapper
{
    CompanyDetailsResponse Map(CompanyInfo? companyInfo);
}