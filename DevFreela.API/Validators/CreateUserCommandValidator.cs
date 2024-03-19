using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.API.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(RuleFor => RuleFor.Email)
                .EmailAddress()
                .WithMessage("Email inválido");

            RuleFor(RuleFor => RuleFor.Password)
                .Must(ValidatePassword!)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maíscula, uma minúscula, e um caractere especial");

            RuleFor(RuleFor => RuleFor.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório");
        }

        public bool ValidatePassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=].*$)");

            return regex.IsMatch(password);
        }

    }
}
