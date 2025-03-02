using Bernhoeft.GRT.Core.Interfaces.Results;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

public record UpdateAvisoCommand(int Id, string Mensagem) : IRequest<IOperationResult<object>>;