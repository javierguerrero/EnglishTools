using Catalog.Persistence;
using Catalog.Service.Queries.DTOs;
using Microsoft.EntityFrameworkCore;
using Service.Common.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Service.Queries
{
    public interface ICharacterQueryService
    {
        Task<IEnumerable<CharacterDto>> GetAllAsync();
    }

    public class CharacterQueryService : ICharacterQueryService
    {
        private readonly ApplicationDbContext _context;

        public CharacterQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CharacterDto>> GetAllAsync()
        {
            var collection = await _context.Characters.ToListAsync();
            return collection.MapTo<IEnumerable<CharacterDto>>();
        }
    }
}