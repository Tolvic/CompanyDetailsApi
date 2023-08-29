using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace ThirdPartyAService.Mappers;

public class AddressMapper : IAddressMapper
{
    public Address? Map(DTOs.Address? address)
    {
        return address is null
            ? null
            : new Address
            {
                Street = address.Street?.Trim().Normalize(),
                City = address.City?.Trim().Normalize(),
                Country = address.Country?.Trim().Normalize(),
                Postcode = address.Postcode?.Trim().Normalize()
            };
    }
}