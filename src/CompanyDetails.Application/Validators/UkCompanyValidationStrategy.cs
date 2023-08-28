using CompanyDetails.Core.Constants;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.Validators;

public class UkCompanyValidationStrategy : SimpleCompanyValidationStrategyBase
{
    public override string Jurisdiction => JurisdictionCode.Uk;

    public UkCompanyValidationStrategy(ILogger<UkCompanyValidationStrategy> logger)
        : base(logger, new HashSet<string> {"1111", "2222"})
    {
    }
}