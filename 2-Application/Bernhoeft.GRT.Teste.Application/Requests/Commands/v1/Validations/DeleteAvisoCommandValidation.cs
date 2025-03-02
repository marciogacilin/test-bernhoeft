using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;

public class DeleteAvisoCommandValidation : AbstractValidator<DeleteAvisoCommand>
{
    public DeleteAvisoCommandValidation()
    {
        RuleFor(i => i.Id)
            .Must(i => i > 0)
            .WithMessage("Identificador inválido");
    }
}
