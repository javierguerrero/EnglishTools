using Api.Gateway.Models.Catalog.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Gateway.BackOffice.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("characters")]
    public class CharacterController : ControllerBase
    {
        private readonly ICatalogProxy _catalogProxy;

        public CharacterController(ICatalogProxy catalogProxy)
        {
            _catalogProxy = catalogProxy;
        }

        [HttpGet]
        public async Task<IEnumerable<CharacterDto>> GetCharacters()
        {
            return await _catalogProxy.GetCharactersAsync();
        }
    }
}