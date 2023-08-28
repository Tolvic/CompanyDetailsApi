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
                Street = address.Street,
                City = address.City,
                Country = address.Country,
                Postcode = address.Postcode
            };
    }
}