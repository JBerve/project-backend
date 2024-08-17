using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;
using Continuum.Infrastructure.Data;

namespace Continuum.Infrastructure.Repositories
{
    public class MediaContentRepository : IMediaContentRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaContentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MediaContent> GetByIdAsync(int id)
        {
            return await _context.MediaContents
                .AsNoTracking()
                .FirstOrDefaultAsync(mc => mc.Id == id);
        }

        public async Task<IEnumerable<MediaContent>> GetByClientIdAsync(int clientId)
        {
            return await _context.MediaContents
                .AsNoTracking()
                .Where(mc => mc.ClientId == clientId)
                .ToListAsync();
        }

        public async Task AddAsync(MediaContent mediaContent)
        {
            await _context.MediaContents.AddAsync(mediaContent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MediaContent mediaContent)
        {
            _context.MediaContents.Update(mediaContent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mediaContent = await _context.MediaContents.FindAsync(id);
            if (mediaContent != null)
            {
                _context.MediaContents.Remove(mediaContent);
                await _context.SaveChangesAsync();
            }
        }
    }
}