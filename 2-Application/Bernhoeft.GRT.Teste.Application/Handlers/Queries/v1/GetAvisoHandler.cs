using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.Enums;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Queries.v1;

public class GetAvisoHandler(IServiceProvider serviceProvider) : IRequestHandler<GetAvisoRequest, IOperationResult<GetAvisoResponse>>
{
    private IAvisoRepository _avisoRepository = serviceProvider.GetRequiredService<IAvisoRepository>();

    public async Task<IOperationResult<GetAvisoResponse>> Handle(GetAvisoRequest request, CancellationToken cancellationToken)
    {
        var result = await _avisoRepository.ObterAvisoAsync(request.Id, TrackingBehavior.NoTracking, cancellationToken);

        if (result is null)
            return OperationResult<GetAvisoResponse>.ReturnNotFound();

        return OperationResult<GetAvisoResponse>.ReturnOk((GetAvisoResponse)result);
    }
}
