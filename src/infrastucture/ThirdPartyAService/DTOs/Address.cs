using System.Text.Json.Serialization;

namespace ThirdPartyAService.DTOs;

public class Address
{
    [JsonPropertyName("street")]
    public string? Street { get; set; }
    
    [JsonPropertyName("city")]
    public string? City { get; set; }
    
    [JsonPropertyName("country")]
    public string? Country { get; set; }
    
    [JsonPropertyName("postcode")]
    public string? Postcode { get; set; }
}