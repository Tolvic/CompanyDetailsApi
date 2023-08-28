using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Core.Interfaces.Validators;

public interface ICompanyDetailsRequestValidator
{
    ValidationResult Validate(CompanyDetailsRequest request);
}