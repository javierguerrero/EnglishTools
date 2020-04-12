using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("characters")]
    public class CharacterController : Controller
    {
        private readonly ICharacterQueryService _characterQueryService;
        private readonly IMediator _mediator;

        public CharacterController(
            ICharacterQueryService characterQueryService,
            IMediator mediator)
        {
            _mediator = mediator;
            _characterQueryService = characterQueryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CharacterDto>> GetAll()
        {
            return await _characterQueryService.GetAllAsync();
        }
    }
}