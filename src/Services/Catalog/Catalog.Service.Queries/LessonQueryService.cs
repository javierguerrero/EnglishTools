using Catalog.Persistence;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
    public interface ILessonQueryService
    {
        Task<DataCollection<LessonDto>> GetAllAsync(int page, int take);

        Task<LessonDto> GetAsync(int id);
    }

    public class LessonQueryService : ILessonQueryService
    {
        private readonly ApplicationDbContext _context;

        public LessonQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<LessonDto>> GetAllAsync(int page, int take)
        {
            var collection = await _context.Lessons
                                        .OrderByDescending(x => x.LessonId)
                                        .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<LessonDto>>();
        }

        public async Task<LessonDto> GetAsync(int id)
        {
            return (await _context.Lessons.SingleAsync(x => x.LessonId == id)).MapTo<LessonDto>();
        }
    }
}