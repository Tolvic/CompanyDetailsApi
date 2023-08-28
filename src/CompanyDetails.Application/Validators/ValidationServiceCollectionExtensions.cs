using CompanyDetails.Core.Interfaces.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyDetails.Application.Validators;

public static class ValidationServiceCollectionExtensions
{
    public static void AddCompanyDetailsRequestValidation(this IServiceCollection services)
    {
        services.AddTransient<ICompanyDetailsRequestValidator, CompanyDetailsRequestValidator>();
        services.AddTransient<ICompanyValidationStrategy, UkCompanyValidationStrategy>();
        services.AddTransient<ICompanyValidationStrategy, GermanyCompanyValidationStrategy>();
        services.AddTransient<ICompanyValidationStrategy, TheNetherlandsCompanyValidationStrategy>();
    }
}