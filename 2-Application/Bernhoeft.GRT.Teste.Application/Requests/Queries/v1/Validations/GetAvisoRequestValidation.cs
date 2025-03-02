using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations;

public class GetAvisoRequestValidation : AbstractValidator<GetAvisoRequest>
{
    public GetAvisoRequestValidation()
    {
        RuleFor(i => i.Id)
            .Must(i => i > 0)
            .WithMessage("Idenificador é obrigatório");
    }
}
