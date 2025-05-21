using FluentValidation;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.CreatePersona;

public class CreatePersonaCommandValidator : AbstractValidator<CreatePersonaCommand>
{
    public CreatePersonaCommandValidator()
    {
        RuleFor(p => p.Nombre)
            .NotNull().WithMessage("{Nombre} no puede ser nulo");

        RuleFor(p => p.Apellido)
            .NotNull().WithMessage("{Apellido} no puede ser nulo");

        RuleFor(p => p.IdRol)
            .NotNull().WithMessage("{IdRol} no puede ser nulo");
    }
}
