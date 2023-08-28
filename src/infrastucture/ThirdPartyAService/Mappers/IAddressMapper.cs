using CompanyDetails.Core.Models;

namespace ThirdPartyAService.Mappers;

public interface IAddressMapper
{
    Address? Map(DTOs.Address? address);
}