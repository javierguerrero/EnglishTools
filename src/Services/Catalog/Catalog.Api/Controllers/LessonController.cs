
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.Queries;
using Catalog.Service.Queries.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;
using System.Net;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("lessons")]
    public class LessonController : Controller
    {
        private readonly ILessonQueryService _lessonQueryService;
        private readonly IMediator _mediator;

        public LessonController(
            ILessonQueryService lessonQueryService,
            IMediator mediator)
        {
            _mediator = mediator;
            _lessonQueryService = lessonQueryService;
        }

        [HttpGet]
        public async Task<DataCollection<LessonDto>> GetAll(int page = 1, int take = 10)
        {
            return await _lessonQueryService.GetAllAsync(page, take);
        }

        [HttpGet("{id}")]
        public async Task<LessonDto> Get(int id)
        {
            return await _lessonQueryService.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LessonCreateCommand notification)
        {
            await _mediator.Publish(notification);
            return Ok();
        }
    }
}