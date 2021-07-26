using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Aplicacion.Deuda;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[Controller]")]
    [Produces("application/json")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [EnableCors("cors_Codevsys")]
    public class DeudaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DeudaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Deuda>>> Get()
        {
            return await _mediator.Send(new ConsultaDeuda.ListaDeudaAutoventa());
        }

    }
}