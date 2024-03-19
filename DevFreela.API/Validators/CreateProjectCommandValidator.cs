using DevFreela.Application.Commands.CreateProject;
using FluentValidation;

namespace DevFreela.API.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                .NotNull()
                .WithMessage("Título é obrigatório");

            RuleFor(p => p.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição é obrigatória");

            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Descrição deve ter no máximo 255 caracteres");

            RuleFor(p => p.TotalCost)
                .GreaterThan(0)
                .WithMessage("Custo total deve ser maior que zero");
        }
    }
}
