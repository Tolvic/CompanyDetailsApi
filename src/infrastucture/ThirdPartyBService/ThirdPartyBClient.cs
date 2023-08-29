using System.Text.Json;
using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ThirdPartyBService.DTOs;

namespace ThirdPartyBService;

    public class ThirdPartyBClient : IThirdPartyBClient
    {
        private readonly HttpClient _httpClient;
        private readonly ThirdPartyServiceOptions _options;
        private readonly ILogger<ThirdPartyBClient> _logger;

        public ThirdPartyBClient(HttpClient httpClient,
            IOptions<ThirdPartyServiceOptions> options,
            ILogger<ThirdPartyBClient> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CompanyInfo?> GetCompanyInfoAsync(CompanyDetailsRequest request)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));
            
            var url = BuildUrl(request);
            _logger.LogDebug("Attempting to fetch company information from {Url}", url);

            HttpResponseMessage response;
            
            try
            {
                response = await _httpClient.GetAsync(url);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while attempting to fetch data: {Ex}", ex);
                return null;
            }

            if (response.IsSuccessStatusCode)
            {
                return await DeserializeResponseAsync(response);
            }

            _logger.LogWarning("Received non-success status code: {ResponseStatusCode}", response.StatusCode);
            // Return null explicitly if we reach here
            return null;
        }
        

        private async Task<CompanyInfo?> DeserializeResponseAsync(HttpResponseMessage response)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            try
            {
                var companyInfo = JsonSerializer.Deserialize<CompanyInfo>(jsonString);
                if (companyInfo != null)
                {
                    _logger.LogDebug($"Successfully fetched company information.");
                    return companyInfo;
                }
            }
            catch (JsonException jsonException)
            {
                _logger.LogError("Failed to deserialize the JSON response: {JsonException}", jsonException);
            }
            return null;
        }

        private string BuildUrl(CompanyDetailsRequest request)
        {
            return $"{_options.BaseUrl}/{_options.ApiVersion}/company-data?jurisdictionCode={request.JurisdictionCode}&companyNumber={request.CompanyNumber}";
        }
    }