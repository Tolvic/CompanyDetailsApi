using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Core.Interfaces.Adapters;

public interface ICompanyDetailsAdapter
{
    public Task<CompanyDetailsResponse> GetCompanyDetailsAsync(CompanyDetailsRequest request);
}