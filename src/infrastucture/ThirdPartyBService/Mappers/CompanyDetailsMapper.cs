using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;
using ThirdPartyBService.DTOs;
using Activity = CompanyDetails.Core.Models.Activity;

namespace ThirdPartyBService.Mappers;

public class CompanyDetailsMapper : ICompanyDetailsMapper
{
    private readonly IActivitiesMapper _activitiesMapper;
    private readonly IDateMapper _dateMapper;
    private readonly IAddressMapper _addressMapper;
    private readonly ILogger<CompanyDetailsMapper> _logger;

    public CompanyDetailsMapper(IActivitiesMapper activitiesMapper,
        IDateMapper dateMapper,
        IAddressMapper addressMapper,
        ILogger<CompanyDetailsMapper> logger)
    {
        _activitiesMapper = activitiesMapper;
        _dateMapper = dateMapper;
        _addressMapper = addressMapper;
        _logger = logger;
    }
    
    public CompanyDetails.Core.Models.CompanyDetails Map(CompanyInfo companyInfo)
    {
        try
        {
            return new()
            {   
                CompanyNumber = companyInfo.CompanyNumber,
                CompanyName = companyInfo.CompanyName,
                CountryCode = companyInfo.Country,
                Activities = _activitiesMapper.Map(companyInfo.Activities),
                DateEstablished = _dateMapper.Map(companyInfo.DateFrom),
                DateDissolved = _dateMapper.Map(companyInfo.DateTo),
                Address = _addressMapper.Map(companyInfo.Address),
            };
        }
        catch (Exception e)
        {
            _logger.LogError("Error mapping company details from ThirdPartyBService: {Exception}", e);
            return new();
        }
    }
}