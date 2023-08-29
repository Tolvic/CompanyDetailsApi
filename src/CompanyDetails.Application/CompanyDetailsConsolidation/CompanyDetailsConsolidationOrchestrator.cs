using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Application.CompanyDetailsConsolidation;

public class CompanyDetailsConsolidationOrchestrator : ICompanyDetailsConsolidationOrchestrator
{
    private readonly ValidationHandler _validationHandler;
    private readonly CompanyDetailsHandler _companyDetailsHandler;
    private readonly ActivitiesHandler _activitiesHandler;
    private readonly AssociatedPersonsHandler _associatedPersonsHandler;
    private readonly AssociatedCompanyHandler _associatedCompanyHandler;


    public CompanyDetailsConsolidationOrchestrator(ValidationHandler validationHandler,
        CompanyDetailsHandler companyDetailsHandler, 
        ActivitiesHandler activitiesHandler,
        AssociatedPersonsHandler associatedPersonsHandler,
        AssociatedCompanyHandler associatedCompanyHandler )
    {
        _validationHandler = validationHandler;
        _companyDetailsHandler = companyDetailsHandler;
        _activitiesHandler = activitiesHandler;
        _associatedPersonsHandler = associatedPersonsHandler;
        _associatedCompanyHandler = associatedCompanyHandler;
    }
    
    public CompanyDetailsResponse? Consolidate(CompanyDetailsRequest request, List<CompanyDetailsResponse> responsesToConsolidate)
    {
        var consolidatedResponse = new CompanyDetailsResponse();

        _validationHandler.SetNext(_companyDetailsHandler);
        _companyDetailsHandler.SetNext(_activitiesHandler);
        _activitiesHandler.SetNext(_associatedPersonsHandler);
        _associatedPersonsHandler.SetNext(_associatedCompanyHandler);

        _validationHandler.Handle(request, responsesToConsolidate, consolidatedResponse);
        
        return consolidatedResponse;
    }
}