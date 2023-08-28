using ThirdPartyBService.DTOs;

namespace ThirdPartyBService.Mappers;

public interface ICompanyDetailsMapper
{
    public CompanyDetails.Core.Models.CompanyDetails Map(CompanyInfo companyInfo);
}