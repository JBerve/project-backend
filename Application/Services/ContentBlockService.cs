using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;

namespace Continuum.Application.Services
{
    public class ContentBlockService : IContentBlockService
    {
        private readonly IContentBlockRepository _contentBlockRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ContentBlockService(IContentBlockRepository contentBlockRepository, IUnitOfWork unitOfWork)
        {
            _contentBlockRepository = contentBlockRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ContentBlock> GetContentBlockByIdAsync(int id)
        {
            return await _contentBlockRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<ContentBlock>> GetAllContentBlocksAsync(int clientId)
        {
            return await _contentBlockRepository.GetByClientIdAsync(clientId);
        }

        public async Task AddContentBlockAsync(ContentBlock contentBlock)
        {
            await _contentBlockRepository.AddAsync(contentBlock);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateContentBlockAsync(ContentBlock contentBlock)
        {
            _contentBlockRepository.UpdateAsync(contentBlock);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteContentBlockAsync(int id)
        {
            await _contentBlockRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}