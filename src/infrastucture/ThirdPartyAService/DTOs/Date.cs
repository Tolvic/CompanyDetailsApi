using System.Text.Json.Serialization;

namespace ThirdPartyAService.DTOs;

public class Date
{
    [JsonPropertyName("year")]
    public int Year { get; set; }
    
    [JsonPropertyName("month")]
    public int Month { get; set; }
    
    [JsonPropertyName("day")]
    public int Day { get; set; }
}