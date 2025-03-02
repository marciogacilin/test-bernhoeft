using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;

public class UpdateAvisoCommandValidation : AbstractValidator<UpdateAvisoCommand>
{
    public UpdateAvisoCommandValidation()
    {
        RuleFor(i => i.Id)
            .Must(i => i > 0)
            .WithMessage("Identificador inválido");

        RuleFor(i => i.Mensagem)
            .Must(i => !string.IsNullOrWhiteSpace(i))
            .WithMessage("Campo obrigatório");
    }
}
