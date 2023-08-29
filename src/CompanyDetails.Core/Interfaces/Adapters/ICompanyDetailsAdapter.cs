using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Core.Interfaces.Adapters;

public interface ICompanyDetailsAdapter
{
    public List<string> Jurisdictions { get; }
    public Task<CompanyDetailsResponse> GetCompanyDetailsAsync(CompanyDetailsRequest request);
}