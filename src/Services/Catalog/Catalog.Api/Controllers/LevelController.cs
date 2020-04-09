
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("levels")]
    public class LevelController : Controller
    {
        private readonly ILevelQueryService _levelQueryService;

        public LevelController(ILevelQueryService levelQueryService)
        {
            _levelQueryService = levelQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<LevelDto>> GetAll(int page = 1, int take = 10)
        {
            return await _levelQueryService.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<LevelDto> Get(int id)
        {
            return await _levelQueryService.GetAsync(id);
        }
    }
}