using CompanyDetails.Core.Interfaces.Validators;
using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.Validators;

public abstract class SimpleCompanyValidationStrategyBase : ICompanyValidationStrategy
{
    private readonly HashSet<string> _validCompanyNumbers;
    private readonly ILogger _logger;
    public abstract string Jurisdiction { get; }
    
    protected SimpleCompanyValidationStrategyBase(ILogger logger, HashSet<string> validCompanyNumbers)
    {
        _logger = logger;
        _validCompanyNumbers = validCompanyNumbers;
    }
    
    public ValidationResult Validate(string companyNumber)
    {
        if (string.IsNullOrWhiteSpace(companyNumber))
        {
            _logger.LogWarning("Company number cannot be null or empty");
            return new ValidationResult { IsValid = false, Reason = "Validation failed" };
        }

        if (!_validCompanyNumbers.Contains(companyNumber))
        {
            _logger.LogInformation("Invalid company number: {CompanyNumber}", companyNumber);
            return new ValidationResult { IsValid = false, Reason = $"Invalid company number: {companyNumber}" };
        }

        return new ValidationResult { IsValid = true };
    }
}