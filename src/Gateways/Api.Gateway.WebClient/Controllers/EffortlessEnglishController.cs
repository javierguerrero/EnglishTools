using Api.Gateway.Models;
using Api.Gateway.Models.EffortlessEnglish.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("effortless-english")]
    public class EffortlessEnglishController : ControllerBase
    {
        private readonly IEffortlessEnglishProxy _effortlessEnglishProxy;

        public EffortlessEnglishController(IEffortlessEnglishProxy effortlessEnglishProxy)
        {
            _effortlessEnglishProxy = effortlessEnglishProxy;
        }

        [HttpGet]
        [Route("levels")]
        public async Task<DataCollection<LevelDto>> GetLevels(int page, int take)
        {
            return await _effortlessEnglishProxy.GetLevelsAsync(page, take);
        }
    }
}