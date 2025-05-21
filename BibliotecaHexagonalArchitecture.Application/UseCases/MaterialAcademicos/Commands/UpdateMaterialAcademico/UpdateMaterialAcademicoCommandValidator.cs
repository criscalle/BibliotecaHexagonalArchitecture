using FluentValidation;

namespace BibliotecaHexagonalArchitecture.Application.UseCases.MaterialAcademicos.Commands.UpdateMaterialAcademico;

public class UpdateMaterialAcademicoCommandValidator : AbstractValidator<UpdateMaterialAcademicoCommand>
{
    public UpdateMaterialAcademicoCommandValidator()
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
