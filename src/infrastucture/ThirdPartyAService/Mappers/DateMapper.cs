using ThirdPartyAService.DTOs;

namespace ThirdPartyAService.Mappers;

public class DateMapper : IDateMapper
{
    public DateOnly? Map(DateOfBirth? dob) => 
        dob is null ? null : DateOnly.FromDateTime(new DateTime(dob.Year, dob.Month, 1));
        
    public DateOnly? Map(Date? date) => 
        date is null ? null : DateOnly.FromDateTime(new DateTime(date.Year, date.Month, date.Month));
}