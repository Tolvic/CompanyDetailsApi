using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public interface ICompanyDetailsConsolidationOrchestrator
{
    CompanyDetailsResponse? Consolidate(CompanyDetailsRequest request, List<CompanyDetailsResponse> responsesToConsolidate);
}