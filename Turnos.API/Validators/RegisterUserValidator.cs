using FluentValidation;
using Turnos.API.DTOs;

namespace Turnos.API.Validators;

public class RegisterUserValidator : AbstractValidator<RegisterUserDto>
{

    public RegisterUserValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}