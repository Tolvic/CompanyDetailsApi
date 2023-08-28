using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Interfaces.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDetails.Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyDetailsRequestValidator _requestValidator;

    public CompanyController(ICompanyDetailsRequestValidator requestValidator)
    {
        _requestValidator = requestValidator;
    }
    
    
    [HttpGet]
    [ApiVersion("1.0")]
    [Route("{jurisdictionCode}/{companyNumber}")]
    public IActionResult GetCompanyDetails([FromRoute] CompanyDetailsRequest request)
    {
        var validationResult = _requestValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Reason);
        }
        
        return Ok();
    }
}

