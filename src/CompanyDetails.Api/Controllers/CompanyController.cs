using Microsoft.AspNetCore.Mvc;

namespace CompanyDetails.Api.Controllers;

[ApiController]
[Route("v{version:apiVersion}/[controller]")]
public class CompanyController : ControllerBase
{
    [HttpGet]
    [ApiVersion("1.0")]
    [Route("{jurisdictionCode}/{companyNumber}")]
    public IActionResult Index(string jurisdictionCode, string companyNumber)
    {
        return Ok();
    }
}