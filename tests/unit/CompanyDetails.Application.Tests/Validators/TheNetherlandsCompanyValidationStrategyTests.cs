using CompanyDetails.Application.Validators;
using CompanyDetails.Core.Constants;
using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.Tests.Validators;

public class TheNetherlandsCompanyValidationStrategyTests
{
    private readonly TheNetherlandsCompanyValidationStrategy _strategy;

    public TheNetherlandsCompanyValidationStrategyTests()
    {
        Mock<ILogger<TheNetherlandsCompanyValidationStrategy>> mockLogger = new();
        _strategy = new TheNetherlandsCompanyValidationStrategy(mockLogger.Object);
    }
    
    
    [Fact]
    public void Jurisdiction_ShouldReturnNetherlands()
    {
        // Arrange

        // Act
        var jurisdiction = _strategy.Jurisdiction;

        // Assert
        jurisdiction.Should().BeEquivalentTo(JurisdictionCode.Netherlands);
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
        var companyNumber = "1111";

        // Act
        var result = _strategy.Validate(companyNumber);

        // Assert
        result.Should().BeEquivalentTo(new ValidationResult { IsValid = false, Reason = "Invalid company number: 1111" });
    }

    [Fact]
    public void Validate_ShouldReturnValid_WhenCompanyNumberIsValid()
    {
        // Arrange
        var companyNumber = "5555";

        // Act
        var result = _strategy.Validate(companyNumber);

        // Assert
        result.Should().BeEquivalentTo(new ValidationResult { IsValid = true });
    }
}