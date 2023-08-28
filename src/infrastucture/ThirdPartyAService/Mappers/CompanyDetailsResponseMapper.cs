using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;
using ThirdPartyAService.DTOs;

namespace ThirdPartyAService.Mappers
{
    public class CompanyDetailsResponseMapper : ICompanyDetailsResponseMapper
    {
        private readonly ICompanyDetailsMapper _companyDetailsMapper;
        private readonly IAssociatedEntitiesMapper _associatedEntitiesMapper;
        private readonly ILogger<CompanyDetailsResponseMapper> _logger;

        public CompanyDetailsResponseMapper(ICompanyDetailsMapper companyDetailsMapper,
            IAssociatedEntitiesMapper associatedEntitiesMapper,
            ILogger<CompanyDetailsResponseMapper> logger)
        {
            _companyDetailsMapper = companyDetailsMapper;
            _associatedEntitiesMapper = associatedEntitiesMapper;
            _logger = logger;
        }

        public CompanyDetailsResponse Map(CompanyInfo? companyInfo)
        {
            try
            {
                return companyInfo is null
                    ? new CompanyDetailsResponse()
                    : new CompanyDetailsResponse
                    {
                        CompanyDetails = _companyDetailsMapper.Map(companyInfo),
                        AssociatedEntities = _associatedEntitiesMapper.Map(companyInfo)
                    };
            }
            catch (Exception e)
            {
                _logger.LogError("Error mapping company details from ThirdPartyAService: {Exception}", e);
                return new CompanyDetailsResponse();
            }
        }
    }
}


