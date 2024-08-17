using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Application.Interfaces
{
    public interface IPageService
    {
        Task<Page> GetPageByIdAsync(int id);
        Task<IEnumerable<Page>> GetAllPagesAsync(int clientId);
        Task AddPageAsync(Page page);
        Task UpdatePageAsync(Page page);
        Task DeletePageAsync(int id);
    }
}