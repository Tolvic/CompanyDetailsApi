namespace CompanyDetails.Core.Options;

public class ThirdPartyServiceOptions
{
    public List<string> Jurisdictions { get; set; } = new List<string>();
    public string BaseUrl { get; set; } = string.Empty;
    public string ApiVersion { get; set; } = string.Empty;
}