using FluentValidation;

namespace Tandem_Diabetes_BE_challenge.Validator
{
    public class EmailValidator : AbstractValidator<string>
    {
        public EmailValidator()
        {
            RuleFor(x => x).EmailAddress().WithMessage("Email address is not valid!");
        }
    }
}
