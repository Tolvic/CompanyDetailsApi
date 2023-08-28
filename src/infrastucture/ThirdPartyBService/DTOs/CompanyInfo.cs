using System.Text.Json.Serialization;

namespace ThirdPartyBService.DTOs;

public class CompanyInfo
{
    [JsonPropertyName("companyNumber")]
    public string? CompanyNumber { get; set; }

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("dateFrom")]
    public string? DateFrom { get; set; }

    [JsonPropertyName("dateTo")]
    public string? DateTo { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("activities")]
    public List<Activity>? Activities { get; set; }

    [JsonPropertyName("relatedPersons")]
    public List<RelatedPerson>? RelatedPersons { get; set; }

    [JsonPropertyName("relatedCompanies")]
    public List<RelatedCompany>? RelatedCompanies { get; set; }
}