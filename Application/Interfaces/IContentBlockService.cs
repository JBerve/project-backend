using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Application.Interfaces
{
    public interface IContentBlockService
    {
        Task<ContentBlock> GetContentBlockByIdAsync(int id);
        Task<IEnumerable<ContentBlock>> GetAllContentBlocksAsync(int clientId);
        Task AddContentBlockAsync(ContentBlock contentBlock);
        Task UpdateContentBlockAsync(ContentBlock contentBlock);
        Task DeleteContentBlockAsync(int id);
    }
}