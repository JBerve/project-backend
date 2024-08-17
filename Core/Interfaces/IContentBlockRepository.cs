using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Core.Interfaces
{
    public interface IContentBlockRepository
    {
        Task<ContentBlock> GetByIdAsync(int id);
        Task<IEnumerable<ContentBlock>> GetByClientIdAsync(int clientId);
        Task AddAsync(ContentBlock contentBlock);
        Task UpdateAsync(ContentBlock contentBlock);
        Task DeleteAsync(int id);
    }
}