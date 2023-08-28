using System.Text.Json.Serialization;

namespace ThirdPartyBService.DTOs;

public class Activity
{
    [JsonPropertyName("activityCode")]
    public int? ActivityCode { get; set; }

    [JsonPropertyName("activityDescription")]
    public string? ActivityDescription { get; set; }
}