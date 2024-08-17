using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Core.Interfaces
{
    public interface IConfigurationRepository
    {
        Task<Configuration> GetByClientIdAsync(int clientId);
        Task AddAsync(Configuration configuration);
        Task UpdateAsync(Configuration configuration);
        Task DeleteAsync(int id);
    }
}