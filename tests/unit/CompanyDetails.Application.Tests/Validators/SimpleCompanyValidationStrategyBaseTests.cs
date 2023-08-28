using CompanyDetails.Application.Validators;
using CompanyDetails.Core.Models;
using Microsoft.Extensions.Logging;

namespace CompanyDetails.Application.Tests.Validators

{
    public class SimpleCompanyValidationStrategyBaseTests
    {
        private readonly Mock<ILogger> _mockLogger;

        public SimpleCompanyValidationStrategyBaseTests()
        {
            _mockLogger = new Mock<ILogger>();
        }

        [Fact]
        public void Validate_ShouldReturnInvalid_WhenCompanyNumberIsNull()
        {
            // Arrange
            var validator = new TestableSimpleCompanyValidationStrategy(
                _mockLogger.Object, 
                new HashSet<string> {"123", "456"});
            
            var expectedResult = new ValidationResult {IsValid = false, Reason = "Validation failed"};

            // Act
            var actualResult = validator.Validate(null!);

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_ShouldReturnInvalid_WhenCompanyNumberIsEmpty(string companyNumber)
        {
            // Arrange
            var validator =
                new TestableSimpleCompanyValidationStrategy(
                    _mockLogger.Object, 
                    new HashSet<string> {"123", "456"});
            
            var expectedResult = new ValidationResult {IsValid = false, Reason = "Validation failed"};

            // Act
            var actualResult = validator.Validate(companyNumber);

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Validate_ShouldReturnInvalid_WhenCompanyNumberIsInvalid()
        {
            // Arrange
            var validator = new TestableSimpleCompanyValidationStrategy(
                _mockLogger.Object, 
                new HashSet<string> {"123", "456"});
            
            var expectedResult = new ValidationResult {IsValid = false, Reason = "Invalid company number: 789"};

            // Act
            var actualResult = validator.Validate("789");

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Validate_ShouldReturnValid_WhenCompanyNumberIsValid()
        {
            // Arrange
            var validator = new TestableSimpleCompanyValidationStrategy(
                _mockLogger.Object, 
                new HashSet<string> {"123", "456"});
            
            var expectedResult = new ValidationResult {IsValid = true};

            // Act
            var actualResult = validator.Validate("123");

            // Assert
            actualResult.Should().BeEquivalentTo(expectedResult);
        }

        private class TestableSimpleCompanyValidationStrategy : SimpleCompanyValidationStrategyBase
        {
            public override string Jurisdiction => "Test";

            public TestableSimpleCompanyValidationStrategy(ILogger logger, HashSet<string> validCompanyNumbers)
                : base(logger, validCompanyNumbers)
            {
            }
        }
    }
}