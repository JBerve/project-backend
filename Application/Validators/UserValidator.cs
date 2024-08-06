using Continuum.Core.Entities;
using FluentValidation;

namespace Continuum.Application.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(user => user.Email).NotEmpty().EmailAddress().WithMessage("A valid email is required.");
        }
    }
}