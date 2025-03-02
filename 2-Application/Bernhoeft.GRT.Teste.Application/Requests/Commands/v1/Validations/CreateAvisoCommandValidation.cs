using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations;

public class CreateAvisoCommandValidation : AbstractValidator<CreateAvisoCommand>
{
    public CreateAvisoCommandValidation()
    {
        RuleFor(i => i.Request.Titulo)
            .Must(i => !string.IsNullOrWhiteSpace(i))
            .WithMessage("Campo obrigatório");

        RuleFor(i => i.Request.Mensagem)
            .Must(i => !string.IsNullOrWhiteSpace(i))
            .WithMessage("Campo obrigatório");
    }
}
