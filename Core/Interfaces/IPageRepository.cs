using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Core.Interfaces
{
    public interface IPageRepository
    {
        Task<Page> GetByIdAsync(int id);
        Task<IEnumerable<Page>> GetByClientIdAsync(int clientId);
        Task AddAsync(Page page);
        Task UpdateAsync(Page page);
        Task DeleteAsync(int id);
    }
}