using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;

namespace Continuum.Application.Services
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SocialMediaService(ISocialMediaRepository socialMediaRepository, IUnitOfWork unitOfWork)
        {
            _socialMediaRepository = socialMediaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SocialMedia> GetSocialMediaByIdAsync(int id)
        {
            return await _socialMediaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<SocialMedia>> GetAllSocialMediaAsync(int clientId)
        {
            return await _socialMediaRepository.GetByClientIdAsync(clientId);
        }

        public async Task AddSocialMediaAsync(SocialMedia socialMedia)
        {
            await _socialMediaRepository.AddAsync(socialMedia);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateSocialMediaAsync(SocialMedia socialMedia)
        {
            _socialMediaRepository.UpdateAsync(socialMedia);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteSocialMediaAsync(int id)
        {
            await _socialMediaRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}