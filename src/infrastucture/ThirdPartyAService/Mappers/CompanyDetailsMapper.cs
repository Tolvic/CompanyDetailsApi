using Microsoft.Extensions.Logging;
using ThirdPartyAService.DTOs;

namespace ThirdPartyAService.Mappers;

public class CompanyDetailsMapper : ICompanyDetailsMapper
{
    private readonly IDateMapper _dateMapper;
    private readonly IAddressMapper _addressMapper;
    private readonly ILogger<CompanyDetailsMapper> _logger;

    public CompanyDetailsMapper(IDateMapper dateMapper, IAddressMapper addressMapper, ILogger<CompanyDetailsMapper> logger)
    {
        _dateMapper = dateMapper;
        _addressMapper = addressMapper;
        _logger = logger;
    }


    public CompanyDetails.Core.Models.CompanyDetails Map(CompanyInfo companyInfo)
    {
        try
        {
            return new CompanyDetails.Core.Models.CompanyDetails
            {
                CompanyName = companyInfo.CompanyName,
                CompanyNumber = companyInfo.CompanyNumber,
                CountryCode = companyInfo.JurisdictionCode,
                CompanyType = companyInfo.CompanyType,
                Status = companyInfo.Status,
                DateEstablished = _dateMapper.Map(companyInfo.DateEstablished),
                DateDissolved = _dateMapper.Map(companyInfo.DateDissolved),
                Address = _addressMapper.Map(companyInfo.OfficialAddress)
            };
        }
        catch (Exception e)
        {
            _logger.LogError("Error mapping company details from ThirdPartyAService: {Exception}", e);
            return new CompanyDetails.Core.Models.CompanyDetails();
        }
    }
}