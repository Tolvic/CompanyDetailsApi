using ThirdPartyAService.DTOs;

namespace ThirdPartyAService.Mappers;

public interface IDateMapper
{
    DateOnly? Map(DateOfBirth? dob);
    DateOnly? Map(Date? date);
}