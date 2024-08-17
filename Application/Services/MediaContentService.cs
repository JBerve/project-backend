using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;

namespace Continuum.Application.Services
{
    public class MediaContentService : IMediaContentService
    {
        private readonly IMediaContentRepository _mediaContentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MediaContentService(IMediaContentRepository mediaContentRepository, IUnitOfWork unitOfWork)
        {
            _mediaContentRepository = mediaContentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MediaContent> GetMediaContentByIdAsync(int id)
        {
            return await _mediaContentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<MediaContent>> GetAllMediaContentsAsync(int clientId)
        {
            return await _mediaContentRepository.GetByClientIdAsync(clientId);
        }

        public async Task AddMediaContentAsync(MediaContent mediaContent)
        {
            await _mediaContentRepository.AddAsync(mediaContent);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateMediaContentAsync(MediaContent mediaContent)
        {
            _mediaContentRepository.UpdateAsync(mediaContent);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteMediaContentAsync(int id)
        {
            await _mediaContentRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}