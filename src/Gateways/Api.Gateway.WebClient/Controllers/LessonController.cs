using Api.Gateway.Models;
using Api.Gateway.Models.Catalog.DTOs;
using Api.Gateway.Proxies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("lessons")]
    public class LessonController : ControllerBase
    {
        private readonly ICatalogProxy _catalogProxy;

        public LessonController(ICatalogProxy catalogProxy)
        {
            _catalogProxy = catalogProxy;
        }

        [HttpGet]
        public async Task<DataCollection<LessonDto>> GetLessons(int page, int take)
        {
            return await _catalogProxy.GetLessonsAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<LessonDto> GetLesson(int id)
        {
            return await _catalogProxy.GetLessonAsync(id);
        }
    }
}