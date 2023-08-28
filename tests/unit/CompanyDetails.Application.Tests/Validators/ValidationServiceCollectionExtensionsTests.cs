using CompanyDetails.Application.Validators;
using CompanyDetails.Core.Interfaces.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyDetails.Application.Tests.Validators;

public class ValidationServiceCollectionExtensionsTests
{
    [Fact]
    public void AddCompanyDetailsRequestValidation_ShouldRegisterServices()
    {
        // Arrange
        var services = new ServiceCollection();

        // Act
        services.AddCompanyDetailsRequestValidation();

        // Assert
        services.Should().Contain(sd => sd.ServiceType == typeof(ICompanyDetailsRequestValidator) && sd.ImplementationType == typeof(CompanyDetailsRequestValidator))
            .And.Contain(sd => sd.ServiceType == typeof(ICompanyValidationStrategy) && sd.ImplementationType == typeof(UkCompanyValidationStrategy))
            .And.Contain(sd => sd.ServiceType == typeof(ICompanyValidationStrategy) && sd.ImplementationType == typeof(GermanyCompanyValidationStrategy))
            .And.Contain(sd => sd.ServiceType == typeof(ICompanyValidationStrategy) && sd.ImplementationType == typeof(TheNetherlandsCompanyValidationStrategy));
    }
}