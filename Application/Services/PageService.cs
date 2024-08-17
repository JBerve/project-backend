using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Application.Interfaces;
using Continuum.Core.Entities;
using Continuum.Core.Interfaces;

namespace Continuum.Application.Services
{
    public class PageService : IPageService
    {
        private readonly IPageRepository _pageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
        {
            _pageRepository = pageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Page> GetPageByIdAsync(int id)
        {
            return await _pageRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Page>> GetAllPagesAsync(int clientId)
        {
            return await _pageRepository.GetByClientIdAsync(clientId);
        }

        public async Task AddPageAsync(Page page)
        {
            await _pageRepository.AddAsync(page);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdatePageAsync(Page page)
        {
            _pageRepository.UpdateAsync(page);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeletePageAsync(int id)
        {
            await _pageRepository.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}