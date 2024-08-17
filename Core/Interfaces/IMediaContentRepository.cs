using System.Collections.Generic;
using System.Threading.Tasks;
using Continuum.Core.Entities;

namespace Continuum.Core.Interfaces
{
    public interface IMediaContentRepository
    {
        Task<MediaContent> GetByIdAsync(int id);
        Task<IEnumerable<MediaContent>> GetByClientIdAsync(int clientId);
        Task AddAsync(MediaContent mediaContent);
        Task UpdateAsync(MediaContent mediaContent);
        Task DeleteAsync(int id);
    }
}