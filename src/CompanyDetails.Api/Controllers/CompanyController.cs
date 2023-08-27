using Microsoft.AspNetCore.Mvc;

namespace CompanyDetails.Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ILogger<CompanyController> _logger;

    public CompanyController(ILogger<CompanyController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    [ApiVersion("1.0")]
    [Route("{jurisdictionCode}/{companyNumber}")]
    public IActionResult Index(string jurisdictionCode, string companyNumber)
    {
        _logger.LogError("This is an error");
        
        return Ok();
    }
}