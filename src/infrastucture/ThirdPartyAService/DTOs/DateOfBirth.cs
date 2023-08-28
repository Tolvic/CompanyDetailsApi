using System.Text.Json.Serialization;

namespace ThirdPartyAService.DTOs;

public class DateOfBirth
{
    [JsonPropertyName("year")]
    public int Year { get; set; }
    
    [JsonPropertyName("month")]
    public int Month { get; set; }
}