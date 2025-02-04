using FireWarningSystem.UiLogic.Validators;
using FluentValidation;
using FluentValidation.TestHelper;

namespace FireWarningSystem.UiLogic.Tests.Validators
{
    [TestClass]
    public class FormValidatorTest
    {
        FormValidatorTestValidator Validator { get; set; } = default!;

        [TestInitialize]
        public void InitialiseTest()
        {
            Validator = new FormValidatorTestValidator();
        }

        [TestMethod]
        public void Test_NoErrors()
        {
            var model = new FormValidatorTestClass()
            {
                TestValue = "Value"
            };

            var result = Validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void Test_Errors()
        {
            var model = new FormValidatorTestClass()
            {
                TestValue = ""
            };

            var result = Validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.TestValue);
        }
    }

    public class FormValidatorTestValidator : FormValidator<FormValidatorTestClass>
    {
        public FormValidatorTestValidator()
        {
            RuleFor(x => x.TestValue)
                .NotEmpty();
        }
    }

    //Generic Test Class is used as FormValidator requires a generic and we can isolate testing it from specific project models
    public class FormValidatorTestClass
    {
        public string TestValue { get; set; } = string.Empty;
    }
}
