using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Application.Interfaces
{
    public interface IConfigurationService
    {
        Task<Configuration> GetConfigurationByClientIdAsync(int clientId);
        Task AddConfigurationAsync(Configuration configuration);
        Task UpdateConfigurationAsync(Configuration configuration);
        Task DeleteConfigurationAsync(int id);
    }
}