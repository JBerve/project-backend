using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;
using Continuum.Infrastructure.Data;

namespace Continuum.Infrastructure.Repositories
{
    public class ContentBlockRepository : IContentBlockRepository
    {
        private readonly ApplicationDbContext _context;

        public ContentBlockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ContentBlock> GetByIdAsync(int id)
        {
            return await _context.ContentBlocks
                .AsNoTracking()
                .FirstOrDefaultAsync(cb => cb.Id == id);
        }

        public async Task<IEnumerable<ContentBlock>> GetByClientIdAsync(int clientId)
        {
            return await _context.ContentBlocks
                .AsNoTracking()
                .Where(cb => cb.ClientId == clientId)
                .ToListAsync();
        }

        public async Task AddAsync(ContentBlock contentBlock)
        {
            await _context.ContentBlocks.AddAsync(contentBlock);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContentBlock contentBlock)
        {
            _context.ContentBlocks.Update(contentBlock);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contentBlock = await _context.ContentBlocks.FindAsync(id);
            if (contentBlock != null)
            {
                _context.ContentBlocks.Remove(contentBlock);
                await _context.SaveChangesAsync();
            }
        }
    }
}