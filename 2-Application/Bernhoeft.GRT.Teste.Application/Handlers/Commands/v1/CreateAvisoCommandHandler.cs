using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Entities;
using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1;

public class CreateAvisoCommandHandler(IServiceProvider serviceProvider) : IRequestHandler<CreateAvisoCommand, IOperationResult<object>>
{
    private IAvisoRepository _avisoRepository = serviceProvider.GetRequiredService<IAvisoRepository>();

    public async Task<IOperationResult<object>> Handle(CreateAvisoCommand command, CancellationToken cancellationToken)
    {
        await _avisoRepository.CriarAvisoAsync(
            new AvisoEntity
            {
                Titulo = command.Request.Titulo,
                Mensagem = command.Request.Mensagem,
            },
            cancellationToken);

        return OperationResult<object>.ReturnCreated();
    }
}
