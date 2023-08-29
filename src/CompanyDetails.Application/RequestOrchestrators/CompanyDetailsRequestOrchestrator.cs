using CompanyDetails.Application.CompanyDetailsConsolidation;
using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Interfaces.Adapters;
using CompanyDetails.Core.Interfaces.Orchestrator;
using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.RequestOrchestrators;

public class CompanyDetailsRequestOrchestrator : ICompanyDetailsRequestOrchestrator
{
    private readonly IEnumerable<ICompanyDetailsAdapter> _thirdPartyServices;
    private readonly ICompanyDetailsConsolidationOrchestrator _consolidationOrchestrator;
    private readonly ILogger<CompanyDetailsRequestOrchestrator> _logger;

    public CompanyDetailsRequestOrchestrator(IEnumerable<ICompanyDetailsAdapter> thirdPartyServices,
        ICompanyDetailsConsolidationOrchestrator consolidationOrchestrator,
        ILogger<CompanyDetailsRequestOrchestrator> logger)
    {
        _thirdPartyServices = thirdPartyServices;
        _consolidationOrchestrator = consolidationOrchestrator;
        _logger = logger;
    }

    public async Task<CompanyDetailsResponse?> Get(CompanyDetailsRequest request)
    {
        var targetServices = GetServicesForJurisdiction(request);
        
        var serviceResponses = await GetServiceResponses(request, targetServices);

        var response = _consolidationOrchestrator.Consolidate(request, serviceResponses);

        return response;
    }
    
    private IEnumerable<ICompanyDetailsAdapter> GetServicesForJurisdiction(CompanyDetailsRequest request)
    {
        var services =  _thirdPartyServices.Where(x => x.Jurisdictions.Contains(request.JurisdictionCode));
        
        if (services is null)
        {
            _logger.LogError("No third party service found for jurisdiction {JurisdictionCode}", request.JurisdictionCode);
            throw new ArgumentOutOfRangeException($"No third party service found for jurisdiction {request.JurisdictionCode}");
        }
        
        return services;
    }

    private async Task<List<CompanyDetailsResponse>> GetServiceResponses(CompanyDetailsRequest request, IEnumerable<ICompanyDetailsAdapter> targetServices)
    {
        var serviceRequestTasks = targetServices.Select(service => 
            service.GetCompanyDetailsAsync(request)).ToList();

        await Task.WhenAll(serviceRequestTasks);

        var responses = new List<CompanyDetailsResponse>();

        foreach (var serviceRequest in serviceRequestTasks)
        {
            if (serviceRequest.IsFaulted)
            {
                _logger.LogError("Error getting company details from service {Exception}", serviceRequest.Exception);
            }
            else
            {
                responses.Add(await serviceRequest);
            }
        }

        return responses;
    }
}