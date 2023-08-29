using Microsoft.AspNetCore.Mvc;

namespace CompanyDetails.Core.DTOs;

public class CompanyDetailsRequest
{
    [FromRoute(Name = "jurisdictionCode")]
    public string JurisdictionCode { get; set; } = string.Empty;
    
    [FromRoute(Name = "companyNumber")]
    public string CompanyNumber { get; set; } = string.Empty;
}