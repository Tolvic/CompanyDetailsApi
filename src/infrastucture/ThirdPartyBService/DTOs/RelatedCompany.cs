using System.Text.Json.Serialization;

namespace ThirdPartyBService.DTOs;

public class RelatedCompany
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("dateFrom")]
    public string? DateFrom { get; set; }

    [JsonPropertyName("dateTo")]
    public string? DateTo { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("ownership")]
    public string? Ownership { get; set; }
}