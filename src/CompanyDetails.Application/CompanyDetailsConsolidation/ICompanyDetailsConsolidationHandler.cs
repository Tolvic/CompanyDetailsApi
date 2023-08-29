using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public interface IConsolidationHandler
{
    void SetNext(IConsolidationHandler handler);
        
    void Handle(CompanyDetailsRequest request,
        List<CompanyDetailsResponse> responsesToConsolidate,
        CompanyDetailsResponse consolidatedResponse);
}