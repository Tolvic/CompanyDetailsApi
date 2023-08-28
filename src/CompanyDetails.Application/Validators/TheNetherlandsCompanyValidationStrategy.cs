using CompanyDetails.Core.Constants;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.Validators;

public class TheNetherlandsCompanyValidationStrategy : SimpleCompanyValidationStrategyBase
{
    public override string Jurisdiction => JurisdictionCode.Netherlands;

    public TheNetherlandsCompanyValidationStrategy(ILogger<TheNetherlandsCompanyValidationStrategy> logger)
        : base(logger, new HashSet<string> {"5555", "6666"})
    {
    }
}