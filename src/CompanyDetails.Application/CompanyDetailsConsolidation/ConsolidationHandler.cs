using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public abstract class ConsolidationHandler : IConsolidationHandler
{
    private IConsolidationHandler? _nextHandler;
    
    public void SetNext(IConsolidationHandler? handler)
    {
        _nextHandler = handler;
    }

    public virtual void Handle(CompanyDetailsRequest request, List<CompanyDetailsResponse> responsesToConsolidate, CompanyDetailsResponse consolidatedResponse)
    {
         _nextHandler?.Handle(request, responsesToConsolidate, consolidatedResponse);
        
    }
}