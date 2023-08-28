using CompanyDetails.Application.Validators;
using CompanyDetails.Core.DTOs;
using CompanyDetails.Core.Interfaces.Validators;
using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.Tests.Validators;

public class CompanyDetailsRequestValidatorTests
{
    private readonly CompanyDetailsRequestValidator _validator;
    private readonly Mock<ICompanyValidationStrategy> _validationStrategyMock;

    public CompanyDetailsRequestValidatorTests()
    {
        Mock<ILogger<CompanyDetailsRequestValidator>> loggerMock = new();
        _validationStrategyMock = new Mock<ICompanyValidationStrategy>();

        _validationStrategyMock.Setup(x => x.Jurisdiction).Returns("US");

        var validationStrategies = new List<ICompanyValidationStrategy> {_validationStrategyMock.Object};
        _validator = new CompanyDetailsRequestValidator(loggerMock.Object, validationStrategies);
    }

    [Fact]
    public void Validate_ShouldReturnValidResult_WhenValidJurisdiction()
    {
        // Arrange
        var request = new CompanyDetailsRequest {JurisdictionCode = "US", CompanyNumber = "123"};
        
        _validationStrategyMock.Setup(x =>
                x.Validate(It.IsAny<string>()))
            .Returns(new ValidationResult {IsValid = true});
        
        var expectedResult = new ValidationResult {IsValid = true};

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void Validate_ShouldReturnInvalidResult_WhenInvalidJurisdiction()
    {
        // Arrange
        var request = new CompanyDetailsRequest {JurisdictionCode = "CA", CompanyNumber = "123"};
        
        var expectedResult = new ValidationResult {IsValid = false, Reason = "Unsupported jurisdiction: CA"};

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Fact]
    public void Validate_ShouldReturnInvalidResult_WhenAnExceptionOccurs()
    {
        // Arrange
        var request = new CompanyDetailsRequest {JurisdictionCode = "US", CompanyNumber = "123"};
        _validationStrategyMock.Setup(x => x.Validate(It.IsAny<string>())).Throws<Exception>();
        
        var expectResult = new ValidationResult {IsValid = false, Reason = "Validation failed"};

        // Act
        var result = _validator.Validate(request);

        // Assert
        result.Should().BeEquivalentTo(expectResult);
    }
}