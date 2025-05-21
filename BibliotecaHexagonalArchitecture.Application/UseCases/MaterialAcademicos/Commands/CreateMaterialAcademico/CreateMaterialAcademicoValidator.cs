using FluentValidation;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.CreateMaterialAcademico;

public class CreateMaterialAcademicoValidator : AbstractValidator<CreateMaterialAcademicoCommand>
{
    public CreateMaterialAcademicoValidator()
    {
        RuleFor(p => p.IdTipoMaterial)
            .NotNull().WithMessage("{IdTipoMaterial} no puede ser nulo");

        RuleFor(p => p.Titulo)
            .NotNull().WithMessage("{Titulo} no puede ser nulo");

        RuleFor(p => p.CantidadDisponible)
            .NotNull().WithMessage("{CantidadDisponible} no puede ser nulo");

        RuleFor(p => p.CantidaRegistrada)
            .NotNull().WithMessage("{CantidaRegistrada} no puede ser nulo");
    }
}
