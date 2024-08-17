using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;
using Continuum.Infrastructure.Data;

namespace Continuum.Infrastructure.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly ApplicationDbContext _context;

        public PageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Page> GetByIdAsync(int id)
        {
            return await _context.Pages
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Page>> GetByClientIdAsync(int clientId)
        {
            return await _context.Pages
                .AsNoTracking()
                .Where(p => p.ClientId == clientId)
                .ToListAsync();
        }

        public async Task AddAsync(Page page)
        {
            await _context.Pages.AddAsync(page);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Page page)
        {
            _context.Pages.Update(page);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            if (page != null)
            {
                _context.Pages.Remove(page);
                await _context.SaveChangesAsync();
            }
        }
    }
}