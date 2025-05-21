using FluentValidation;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.Personas.Commands.UpdatePersona;

public class UpdatePersonaCommandValidator : AbstractValidator<UpdatePersonaCommand>
{
    public UpdatePersonaCommandValidator()
    {
        RuleFor(r => r.Nombre)
            .NotNull().WithMessage("${Nombre} no permite nulos");

        RuleFor(r => r.Apellido)
            .NotNull().WithMessage("${Apellido} no permite nulos");

        RuleFor(r => r.IdRol)
            .NotNull().WithMessage("${IdRol} no permite nulos");

    }
}
