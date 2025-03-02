using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1;

public class DeleteAvisoCommandHandler(IServiceProvider serviceProvider) : IRequestHandler<DeleteAvisoCommand, IOperationResult<object>>
{
    private IAvisoRepository _avisoRepository = serviceProvider.GetRequiredService<IAvisoRepository>();

    public async Task<IOperationResult<object>> Handle(DeleteAvisoCommand request, CancellationToken cancellationToken)
    {
        var entity = await _avisoRepository.ObterAvisoAsync(request.Id, TrackingBehavior.NoTracking, cancellationToken);

        if (entity is null)
            return OperationResult<object>.ReturnNotFound();

        entity.SetAtivo(false);

        await _avisoRepository.AlterarAvisoAsync(entity, cancellationToken);

        return OperationResult<object>.ReturnNoContent();
    }
}
