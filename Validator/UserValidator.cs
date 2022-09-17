using FluentValidation;
using Tandem_Diabetes_BE_challenge.DTOs;

namespace Tandem_Diabetes_BE_challenge.Validator
{
    public class UserValidator: AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).Length(0, 10);
            RuleFor(x => x.MiddleName).Length(0, 10);
            RuleFor(x => x.LastName).Length(0, 10);
            RuleFor(x => x.EmailAddress).EmailAddress();
            RuleFor(x => x.PhoneNumber).Length(9, 11);
        }
    }
}
