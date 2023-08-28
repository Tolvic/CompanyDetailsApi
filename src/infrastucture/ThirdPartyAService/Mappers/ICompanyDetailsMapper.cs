using ThirdPartyAService.DTOs;

namespace ThirdPartyAService.Mappers;

public interface ICompanyDetailsMapper
{
    CompanyDetails.Core.Models.CompanyDetails Map(CompanyInfo companyInfo);
}