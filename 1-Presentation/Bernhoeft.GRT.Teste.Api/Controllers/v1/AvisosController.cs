using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using Bernhoeft.GRT.Teste.Application.Responses.Queries.v1;

namespace Bernhoeft.GRT.Teste.Api.Controllers.v1
{
    /// <response code="401">Não Autenticado.</response>
    /// <response code="403">Não Autorizado.</response>
    /// <response code="500">Erro Interno no Servidor.</response>
    [AllowAnonymous]
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = null)]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = null)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = null)]
    public class AvisosController : RestApiController
    {
        ///// <summary>
        ///// Retorna um Aviso por ID.
        ///// </summary>
        ///// <param name="request"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns>Aviso.</returns>
        ///// <response code="200">Sucesso.</response>
        ///// <response code="400">Dados Inválidos.</response>
        ///// <response code="404">Aviso Não Encontrado.</response>
        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAvisoResponse))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[JwtAuthorize(Roles = AuthorizationRoles.CONTRACTLAYOUT_SISTEMA_AVISO_PESQUISAR)]
        //public async Task<object> GetAviso([FromModel] GetAvisoRequest request, CancellationToken cancellationToken)
        //    => await Mediator.Send(request, cancellationToken);

        /// <summary>
        /// Retorna Todos os Avisos Cadastrados para Tela de Edição.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Lista com Todos os Avisos.</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Sem Avisos.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDocumentationRestResult<IEnumerable<GetAvisosResponse>>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<object> GetAvisos(CancellationToken cancellationToken)
            => await Mediator.Send(new GetAvisosRequest(), cancellationToken);


        /// <summary>
        /// Cria um novo Aviso
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<object> CreateAviso([FromBody] CreateAvisoRequest request, CancellationToken cancellationToken)
            => await Mediator.Send(new CreateAvisoCommand(request), cancellationToken);

        /// <summary>
        /// Retorna um aviso cadastrado a partir do identificador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDocumentationRestResult<GetAvisoResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<object> GetAviso([FromRoute] int id, CancellationToken cancellationToken)
            => await Mediator.Send(new GetAvisoRequest(id), cancellationToken);


        /// <summary>
        /// Altera a mensagem de um aviso cadastrado
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<object> UpdateAviso([FromRoute] int id, [FromBody] UpdateAvisoRequest request, CancellationToken cancellationToken)
            => await Mediator.Send(new UpdateAvisoCommand(id, request.Mensagem), cancellationToken);


        /// <summary>
        /// Remove a mensagem cadastrada
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<object> DeleteAviso([FromRoute] int id, CancellationToken cancellationToken)
            => await Mediator.Send(new DeleteAvisoCommand(id), cancellationToken);
    }
}