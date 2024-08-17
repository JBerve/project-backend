using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;
using Continuum.Infrastructure.Data;

namespace Continuum.Infrastructure.Repositories
{
    public class SocialMediaRepository : ISocialMediaRepository
    {
        private readonly ApplicationDbContext _context;

        public SocialMediaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SocialMedia> GetByIdAsync(int id)
        {
            return await _context.SocialMedia
                .AsNoTracking()
                .FirstOrDefaultAsync(sm => sm.Id == id);
        }

        public async Task<IEnumerable<SocialMedia>> GetByClientIdAsync(int clientId)
        {
            return await _context.SocialMedia
                .AsNoTracking()
                .Where(sm => sm.ClientId == clientId)
                .ToListAsync();
        }

        public async Task AddAsync(SocialMedia socialMedia)
        {
            await _context.SocialMedia.AddAsync(socialMedia);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SocialMedia socialMedia)
        {
            _context.SocialMedia.Update(socialMedia);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var socialMedia = await _context.SocialMedia.FindAsync(id);
            if (socialMedia != null)
            {
                _context.SocialMedia.Remove(socialMedia);
                await _context.SaveChangesAsync();
            }
        }
    }
}