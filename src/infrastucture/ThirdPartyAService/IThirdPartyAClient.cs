using CompanyDetails.Core.DTOs;
using ThirdPartyAService.DTOs;

namespace ThirdPartyAService;

public interface IThirdPartyAClient
{
    Task<CompanyInfo?> GetCompanyInfoAsync(CompanyDetailsRequest request);
}