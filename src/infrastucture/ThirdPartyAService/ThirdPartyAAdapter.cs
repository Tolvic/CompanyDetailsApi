using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Interfaces.Adapters;
using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;
using ThirdPartyAService.Mappers;


namespace ThirdPartyAService;

public class ThirdPartyAAdapter : ICompanyDetailsAdapter
{
    private readonly IThirdPartyAClient _client;
    private readonly ICompanyDetailsResponseMapper _mapper;
    private readonly ILogger<ThirdPartyAAdapter> _logger;

    public ThirdPartyAAdapter(IThirdPartyAClient client,
        ICompanyDetailsResponseMapper mapper,
        ILogger<ThirdPartyAAdapter> logger)
    {
        _client = client;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<CompanyDetailsResponse> GetCompanyDetailsAsync(CompanyDetailsRequest request)
    {
        try
        {
            var companyInfo = await _client.GetCompanyInfoAsync(request);
            return _mapper.Map(companyInfo);
        }
        catch (Exception e)
        {
            _logger.LogError("Error getting company details from ThirdPartyAService: {Exception}", e);
            return new CompanyDetailsResponse();
        }
    }
}