using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Core.Interfaces.Orchestrator;

public interface ICompanyDetailsRequestOrchestrator
{
    Task<CompanyDetailsResponse?> Get(CompanyDetailsRequest request);
}