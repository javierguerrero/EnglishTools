using EffortlessEnglish.Persistence;
using EffortlessEnglish.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffortlessEnglish.Service.Queries
{
    public interface ILevelQueryService
    {
        Task<DataCollection<LevelDto>> GetAllAsync(int page, int take);
        Task<LevelDto> GetAsync(int id);
    }

    public class LevelQueryService : ILevelQueryService
    {
        private readonly ApplicationDbContext _context;

        public LevelQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<LevelDto>> GetAllAsync(int page, int take)
        {
            var collection = await _context.Levels
                                        .OrderByDescending(x => x.LevelId)
                                        .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<LevelDto>>();
        }

        public async Task<LevelDto> GetAsync(int id)
        {
            return (await _context.Levels.SingleAsync(x => x.LevelId == id)).MapTo<LevelDto>();
        }
    }
}
