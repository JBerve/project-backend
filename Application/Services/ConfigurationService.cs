using System.Threading.Tasks;
using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;

namespace Continuum.Application.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfigurationRepository _configurationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConfigurationService(IConfigurationRepository configurationRepository, IUnitOfWork unitOfWork)
        {
            _configurationRepository = configurationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Configuration> GetConfigurationByClientIdAsync(int clientId)
        {
            return await _configurationRepository.GetByClientIdAsync(clientId);
        }

        public async Task AddConfigurationAsync(Configuration configuration)
        {
            await _configurationRepository.AddAsync(configuration);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateConfigurationAsync(Configuration configuration)
        {
            _configurationRepository.UpdateAsync(configuration);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteConfigurationAsync(int id)
        {
            await _configurationRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}