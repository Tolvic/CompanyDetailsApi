using CompanyDetails.Core.Constants;
using CompanyDetails.Core.Interfaces.Validators;
using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.Validators;

public class GermanyCompanyValidationStrategy: SimpleCompanyValidationStrategyBase
{
    public override string Jurisdiction => JurisdictionCode.Germany;
    
    public GermanyCompanyValidationStrategy(ILogger<GermanyCompanyValidationStrategy> logger) 
        : base(logger, new HashSet<string> {"3333", "4444"})
    {
    }
}