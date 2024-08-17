using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;
using Continuum.Infrastructure.Data;

namespace Continuum.Infrastructure.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly ApplicationDbContext _context;

        public ConfigurationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Configuration> GetByClientIdAsync(int clientId)
        {
            return await _context.Configurations
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.ClientId == clientId);
        }

        public async Task AddAsync(Configuration configuration)
        {
            await _context.Configurations.AddAsync(configuration);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Configuration configuration)
        {
            _context.Configurations.Update(configuration);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var configuration = await _context.Configurations.FindAsync(id);
            if (configuration != null)
            {
                _context.Configurations.Remove(configuration);
                await _context.SaveChangesAsync();
            }
        }
    }
}