using CompanyDetails.Core.DTOs;
using ThirdPartyBService.DTOs;

namespace ThirdPartyBService;

public interface IThirdPartyBClient
{
    Task<CompanyInfo?> GetCompanyInfoAsync(CompanyDetailsRequest request);
}