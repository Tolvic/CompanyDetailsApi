using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace ThirdPartyBService.Mappers;

public class AddressMapper : IAddressMapper
{
    private readonly ILogger<AddressMapper> _logger;

    public AddressMapper(ILogger<AddressMapper> logger)
    {
        _logger = logger;
    }
    
    public Address? Map(string? address)
    {
        try
        {
            if (address is null) return null;
            
            //TODO this is a very naive implementation and should be improved
            // We should also consider using a service to parse and validate the address
            // For example: https://developers.google.com/maps/documentation/address-validation/overview

            var splitAddress = address.Split(',');
            
            if (splitAddress.Length != 4)
            {
                _logger.LogWarning("Failed to parse address: {Address}", address);
                return null;
            }
            
            return new Address
            {
                Street = splitAddress[0],
                City = splitAddress[1],
                Country = splitAddress[2],
                Postcode = splitAddress[3]
            };

        }
        catch (Exception e)
        {
            _logger.LogError("Error mapping address from ThirdPartyBService: {Exception}", e);
            return null;
        }
    }
}