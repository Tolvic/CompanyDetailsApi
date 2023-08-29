using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Interfaces.Adapters;
using CompanyDetails.Core.Models;
using CompanyDetails.Core.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThirdPartyBService.Mappers;

namespace ThirdPartyBService;

public class ThirdPartyBAdapter: ICompanyDetailsAdapter
{
    private readonly IThirdPartyBClient _client;
    private readonly ICompanyDetailsResponseMapper _mapper;
    private readonly ILogger<ThirdPartyBAdapter> _logger;

    public List<string> Jurisdictions { get; }
    public ThirdPartyBAdapter(IOptions<ThirdPartyServiceOptions> options,
        IThirdPartyBClient client,
        ICompanyDetailsResponseMapper mapper,
        ILogger<ThirdPartyBAdapter> logger)
    {
        Jurisdictions = options.Value.Jurisdictions;
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