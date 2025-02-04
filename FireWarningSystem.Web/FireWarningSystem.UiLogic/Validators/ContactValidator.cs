using FireWarningSystem.UiLogic.Models;
using FluentValidation;

namespace FireWarningSystem.UiLogic.Validators
{
    public class ContactValidator : FormValidator<ContactModel>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Message)
                .NotEmpty()
                .WithMessage("Please include a body to your message.");
        }
    }
}
