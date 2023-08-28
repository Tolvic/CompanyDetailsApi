using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Models;

namespace CompanyDetails.Core.Interfaces.Validators;

public interface ICompanyValidationStrategy
{
    string Jurisdiction { get; }
    ValidationResult Validate(string companyNumber);
}