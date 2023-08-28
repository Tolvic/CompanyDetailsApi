using CompanyDetails.Core.Models;

namespace ThirdPartyBService.Mappers;

public interface IAddressMapper
{
    public Address? Map(string? address);
}