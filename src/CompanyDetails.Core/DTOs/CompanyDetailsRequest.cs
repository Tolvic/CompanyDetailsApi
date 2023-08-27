using Microsoft.AspNetCore.Mvc;

namespace CompanyDetails.Core.DTOs;

public class CompanyDetailsRequest
{
    [FromRoute]
    public string JurisdictionCode { get; set; } = string.Empty;
    
    [FromRoute]
    public string CompanyNumber { get; set; } = string.Empty;
}