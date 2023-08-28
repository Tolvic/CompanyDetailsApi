using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Interfaces.Validators;
using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.Validators;

public class CompanyDetailsRequestValidator : ICompanyDetailsRequestValidator
{
    private readonly ILogger<CompanyDetailsRequestValidator> _logger;
    private readonly Dictionary<string, ICompanyValidationStrategy> _validationStrategies;

    public CompanyDetailsRequestValidator(ILogger<CompanyDetailsRequestValidator> logger, IEnumerable<ICompanyValidationStrategy> validationStrategies)
    {
        _logger = logger;
        _validationStrategies = validationStrategies.ToDictionary(s => s.Jurisdiction);
    }

    public ValidationResult Validate(CompanyDetailsRequest request)
    {
        try
        {
            ValidationResult result;
        
            if (_validationStrategies.TryGetValue(request.JurisdictionCode, out var strategy))
            {
                result = strategy.Validate(request.CompanyNumber);
            }
            else
            {
                // No validation strategy found for the jurisdiction
                result = new ValidationResult { IsValid = false, Reason = $"Unsupported jurisdiction: {request.JurisdictionCode}" };
            }
        
            if (!result.IsValid)
            {
                _logger.LogInformation("Validation failed. Request: {@Request}, Result: {@Result}", request, result);
                return result;
            }
        
            return new ValidationResult { IsValid = true };
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An exception occurred during validation. Request: {@Request}", request);
            return new ValidationResult { IsValid = false, Reason = "Validation failed" };
        }

    }
}


