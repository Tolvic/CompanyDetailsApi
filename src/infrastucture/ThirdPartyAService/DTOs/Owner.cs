using System.Text.Json.Serialization;

namespace ThirdPartyAService.DTOs;

public class Owner
{
    [JsonPropertyName("first_name")]
    public string? FirstName { get; set; }
    
    [JsonPropertyName("middlenames")]
    public string? Middlenames { get; set; }
    
    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("date_from")]
    public Date? DateFrom { get; set; }
    
    [JsonPropertyName("date_to")]
    public Date? DateTo { get; set; }
    
    [JsonPropertyName("ownership_type")]
    public string? OwnershipType { get; set; }
    
    [JsonPropertyName("shares_held")]
    public double? SharesHeld { get; set; }
    
    [JsonPropertyName("date_of_birth")]
    public DateOfBirth? DateOfBirth { get; set; }
}