using System.Globalization;
using Microsoft.Extensions.Logging;

namespace ThirdPartyBService.Mappers;

public class DateMapper : IDateMapper
{
    //TODO - move format to config
    private const string Format = "dd/MM/yyyy";
    private readonly ILogger<DateMapper> _logger;

    public DateMapper(ILogger<DateMapper> logger)
    {
        _logger = logger;
    }
    public DateOnly? Map(string? date)
    {
        try
        {
            if (date is null) return null;
            
            if (DateTime.TryParseExact(date, Format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
            {
                return DateOnly.FromDateTime(parsedDate);
            }
            else
            {
                _logger.LogWarning("Failed to parse date: {Date}", date);
                return null;
            }
        }
        catch (Exception e)
        {
            _logger.LogError("Error mapping date from ThirdPartyBService: {Exception}", e);
            return null;
        }
    }
}