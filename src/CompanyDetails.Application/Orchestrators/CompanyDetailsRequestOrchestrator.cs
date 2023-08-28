using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Interfaces.Adapters;
using CompanyDetails.Core.Interfaces.Orchestrator;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.Orchestrators;

public class CompanyDetailsRequestOrchestrator : ICompanyDetailsRequestOrchestrator
{
    private readonly ICompanyDetailsAdapter _thirdPartyService;

    public CompanyDetailsRequestOrchestrator(ICompanyDetailsAdapter thirdPartyService)
    {
        _thirdPartyService = thirdPartyService;
    }

    public async Task<CompanyDetailsResponse> Get(CompanyDetailsRequest request)
    {
        return await _thirdPartyService.GetCompanyDetailsAsync(request);
    }
}