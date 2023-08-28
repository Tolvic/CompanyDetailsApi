using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Interfaces.Orchestrator;
using CompanyDetails.Core.Interfaces.Validators;
using Microsoft.AspNetCore.Mvc;

namespace CompanyDetails.Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyDetailsRequestValidator _requestValidator;
    private readonly ICompanyDetailsRequestOrchestrator _orchestrator;

    public CompanyController(ICompanyDetailsRequestValidator requestValidator, ICompanyDetailsRequestOrchestrator orchestrator)
    {
        _requestValidator = requestValidator;
        _orchestrator = orchestrator;
    }
    
    
    [HttpGet]
    [ApiVersion("1.0")]
    [Route("{jurisdictionCode}/{companyNumber}")]
    public async Task<IActionResult> GetCompanyDetails([FromRoute] CompanyDetailsRequest request)
    {
        var validationResult = _requestValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Reason);
        }
        
        var response = await _orchestrator.Get(request);
        
        return Ok(response);
    }
}

