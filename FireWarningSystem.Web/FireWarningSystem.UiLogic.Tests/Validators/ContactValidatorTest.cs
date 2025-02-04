using FireWarningSystem.UiLogic.Models;
using FireWarningSystem.UiLogic.Validators;
using FluentValidation.TestHelper;

namespace FireWarningSystem.UiLogic.Tests.Validators
{
    [TestClass]
    public class ContactValidatorTest
    {
        ContactValidator Validator { get; set; } = default!;

        [TestInitialize]
        public void InitialiseTest()
        {
            Validator = new ContactValidator();
        }

        [TestMethod]
        public void Validate()
        {
            var model = new ContactModel()
            {
                Name = "john smith",
                Email = "john@gmail.com",
                Message = "my message"
            };


            var result = Validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void Validate_Failures_Empty()
        {
            var model = new ContactModel();


            var result = Validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Name);
            result.ShouldHaveValidationErrorFor(x => x.Email);
            result.ShouldHaveValidationErrorFor(x => x.Message);
        }

        [TestMethod]
        public void Validate_InvalidEmail()
        {
            var model = new ContactModel()
            {
                Email = "johngmail.com"
            };

            var result = Validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Email)
                .WithErrorMessage("'Email' is not a valid email address.");
        }
    }
}
