using CompanyDetails.Application.Validators;
using CompanyDetails.Core.Constants;
using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.Tests.Validators;

public class UkCompanyValidationStrategyTests
{
    private readonly UkCompanyValidationStrategy _strategy;

    public UkCompanyValidationStrategyTests()
    {
        Mock<ILogger<UkCompanyValidationStrategy>> mockLogger = new();
        _strategy = new UkCompanyValidationStrategy(mockLogger.Object);
    }
    
    
    [Fact]
    public void Jurisdiction_ShouldReturnUk()
    {
        // Arrange

        // Act
        var jurisdiction = _strategy.Jurisdiction;

        // Assert
        jurisdiction.Should().BeEquivalentTo(JurisdictionCode.Uk);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Validate_ShouldReturnInvalid_WhenCompanyNumberIsEmpty(string companyNumber)
    {
        // Arrange

        // Act
        var result = _strategy.Validate(companyNumber);

        // Assert
        result.Should().BeEquivalentTo(new ValidationResult { IsValid = false, Reason = "Validation failed" });
    }

    [Fact]
    public void Validate_ShouldReturnInvalid_WhenCompanyNumberIsInvalid()
    {
        // Arrange
        var companyNumber = "3333";

        // Act
        var result = _strategy.Validate(companyNumber);

        // Assert
        result.Should().BeEquivalentTo(new ValidationResult { IsValid = false, Reason = "Invalid company number: 3333" });
    }

    [Fact]
    public void Validate_ShouldReturnValid_WhenCompanyNumberIsValid()
    {
        // Arrange
        var companyNumber = "1111";

        // Act
        var result = _strategy.Validate(companyNumber);

        // Assert
        result.Should().BeEquivalentTo(new ValidationResult { IsValid = true });
    }
}