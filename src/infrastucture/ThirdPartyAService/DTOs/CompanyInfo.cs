using System.Text.Json.Serialization;

namespace ThirdPartyAService.DTOs;

public class CompanyInfo
{
    [JsonPropertyName("company_number")]
    public string? CompanyNumber { get; set; }
    
    [JsonPropertyName("company_name")]
    public string? CompanyName { get; set; }
    
    [JsonPropertyName("jurisdiction_code")]
    public string? JurisdictionCode { get; set; }
    
    [JsonPropertyName("company_type")]
    public string? CompanyType { get; set; }
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("date_established")]
    public Date? DateEstablished { get; set; }
    
    [JsonPropertyName("date_dissolved")]
    public Date? DateDissolved { get; set; }
    
    [JsonPropertyName("official_address")]
    public Address? OfficialAddress { get; set; }
    
    [JsonPropertyName("officers")]
    public List<Officer>? Officers { get; set; }
    
    [JsonPropertyName("owners")]
    public List<Owner>? Owners { get; set; }
}